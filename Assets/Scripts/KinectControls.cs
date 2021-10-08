using System.Globalization;
using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;

public enum JOINT_NAME
{
  MidSpine = 0,
  Neck,
  Head,
  LeftShoulder,
  LeftElbow,
  LeftHand,
  RightShoulder,
  RightElbow,
  RightHand
}

[System.Serializable]
public class CharacterJoint
{
  public GameObject joint;
  public Vector3 DefaultPos { get; private set; }
  public Vector3 DefaultRot { get; private set; }

  public void SetDefaultPos(Vector3 pos)
  {
    DefaultPos = pos;
  }

  public void SetDefaultRot(Vector3 rot)
  {
    DefaultRot = rot;
  }
}

public class KinectControls : KinectControlsBehavior
{
  //struct for jointdata
  private struct KinectJoint
  {
    public Vector3 jointPos;
    public Quaternion jointRot;
  }

  [SerializeField]
  private bool kinectV1;
  private const float V1_MODIFIER = 180f;
  private float kinectModifier = 0;

  //array for joints
  private KinectJoint[] kinectJoint;
  private bool kinectJointsSynced = false;

  //length of JointName
  private const int NUM_JOINTS = 9;

  private bool initialised = false;

  public CharacterJoint [] characterJoints;

  private void Awake()
  {
    kinectJoint = new KinectJoint[NUM_JOINTS];

    for (int i = 0; i < kinectJoint.Length; i++)
    {
      kinectJoint[i] = new KinectJoint { jointPos = new Vector3(), jointRot = new Quaternion() };

      characterJoints[i].SetDefaultPos(characterJoints[i].joint.transform.position);
      characterJoints[i].SetDefaultRot(characterJoints[i].joint.transform.rotation.eulerAngles);
    }

    initialised = true;
  }

  private void Start()
  {
    kinectV1 = PlayerPrefs.GetInt("v1") != 0;
    kinectModifier = (PlayerPrefs.GetInt("v1") != 0) ? V1_MODIFIER : 0f;
  }

  public void SetKinectJoints(string input)
  {
    // Only owning client should receive kinect joints
    if (networkObject != null && !networkObject.IsOwner || initialised == false)
    {
      return;
    }

    string[] sortedInput = input.Split(',');

    //per each joint extract vector and quaternion 7 values in total
    if (sortedInput.Length != kinectJoint.Length * 7) ;
    //print("amount of input vars and joint vars are not the same");

    else
    {
      for (int i = 0; i < sortedInput.Length; i++)
      {
        int x = i / 7;
        int y = i % 7;

        CultureInfo newCulture = new CultureInfo("en-US");

        float tempVal = float.Parse(sortedInput[i], newCulture);

        switch (y)
        {
          case 0:
            kinectJoint[x].jointPos.x = tempVal;
            break;
          case 1:
            kinectJoint[x].jointPos.y = tempVal;
            break;
          case 2:
            kinectJoint[x].jointPos.z = tempVal;
            break;
          case 3:
            kinectJoint[x].jointRot.x = tempVal;
            break;
          case 4:
            kinectJoint[x].jointRot.y = tempVal;
            break;
          case 5:
            kinectJoint[x].jointRot.z = tempVal;
            break;
          case 6:
            kinectJoint[x].jointRot.w = tempVal;
            break;
        }
      }

      kinectJointsSynced = true;
    }
  }

  public Vector3 GetJointPosition(JOINT_NAME jointname)
  {
    return kinectJoint[(int)jointname].jointPos;
  }

  public Quaternion GetJointRotation(JOINT_NAME jointname)
  {
    return kinectJoint[(int)jointname].jointRot;
  }

  private void Update()
  {
    if (networkObject == null)
    {
      kinectV1 = PlayerPrefs.GetInt("v1") != 0;
      kinectModifier = (PlayerPrefs.GetInt("v1") != 0) ? V1_MODIFIER : 0f;
    }

    // Check to see if we are NOT the owner of this player
    if (networkObject != null && !networkObject.IsOwner)
    {
      // Set this object's transform.position
      // to the position that is syndicated across the network
      // In simpler words, its position is updated via the network.
      //characterJoints[(int)JOINT_NAME.MidSpine].joint.transform.rotation = networkObject.spineRotation;
      characterJoints[(int)JOINT_NAME.Neck].joint.transform.rotation = networkObject.neckRotation;
      characterJoints[(int)JOINT_NAME.Head].joint.transform.rotation = networkObject.headRotation;
      characterJoints[(int)JOINT_NAME.LeftShoulder].joint.transform.rotation = networkObject.leftShoulderRotation;
      characterJoints[(int)JOINT_NAME.LeftElbow].joint.transform.rotation = networkObject.leftElbowRotation;
      characterJoints[(int)JOINT_NAME.RightShoulder].joint.transform.rotation = networkObject.rightShoulderRotation;
      characterJoints[(int)JOINT_NAME.RightElbow].joint.transform.rotation = networkObject.rightElbowRotation;

      return;
    }

    if (kinectJointsSynced)
    {
      for (int i = 0; i < NUM_JOINTS; ++i)
      {
        switch (i)
        {
          // Maps the orientation of the model, the x-axis is used for the orientation of shoulder center (neck)
          case (int)JOINT_NAME.MidSpine:
            Vector3 rotVecSpine = characterJoints[i].DefaultRot + new Vector3(0, 0, -90f) + kinectJoint[i].jointRot.eulerAngles;
            Vector3 rotVecNeck = new Vector3();

            rotVecNeck.y = rotVecSpine.x;

            rotVecSpine.x = 0;
            rotVecSpine.y = rotVecSpine.z + kinectModifier; // Kinect V1 + 180f
            rotVecSpine.z = -90f;

            //characterJoints[i].joint.transform.rotation = Quaternion.Euler(rotVecSpine);
            characterJoints[(int)JOINT_NAME.Neck].joint.transform.localRotation = Quaternion.Euler(rotVecNeck);

            if (networkObject != null)
            {
              //networkObject.spineRotation = characterJoints[i].joint.transform.rotation;
              networkObject.neckRotation = characterJoints[(int)JOINT_NAME.Neck].joint.transform.rotation;
            }
            

            break;

          // Since kinect head has no orientation, it takes from the kinect neck instead
          case (int)JOINT_NAME.Head:
            Vector3 rotVecHead = characterJoints[i].DefaultRot + new Vector3(0, 0, 90f) + kinectJoint[(int)JOINT_NAME.Neck].jointRot.eulerAngles;

            rotVecHead.x = rotVecHead.z - 90f + kinectModifier; // Kinect V1
            rotVecHead.z = 90f;

            characterJoints[i].joint.transform.localRotation = Quaternion.Euler(rotVecHead);

            if (networkObject != null)
            {
               networkObject.headRotation = characterJoints[i].joint.transform.rotation;
            }

            break;

          case (int)JOINT_NAME.LeftShoulder:
            // Find the local vector of the kinect Left Shoulder to Left Elbow
            Vector3 lsToLe = kinectJoint[(int)JOINT_NAME.LeftElbow].jointPos - kinectJoint[i].jointPos;
            lsToLe.z *= -1;
            Vector3 lsLookAtLe = characterJoints[i].joint.transform.position + lsToLe;

            characterJoints[i].joint.transform.LookAt(lsLookAtLe);
            characterJoints[i].joint.transform.Rotate(Vector3.down, -gameObject.transform.rotation.eulerAngles.y, Space.World);

            if (networkObject != null)
            {
              networkObject.leftShoulderRotation = characterJoints[i].joint.transform.rotation;
            }           

            break;

          case (int)JOINT_NAME.LeftElbow:
            // Find the local vector of the kinect Left Shoulder to Left Elbow
            Vector3 leToLh= kinectJoint[(int)JOINT_NAME.LeftHand].jointPos - kinectJoint[i].jointPos;
            leToLh.z *= -1;
            Vector3 leLookAtLh = characterJoints[i].joint.transform.position + leToLh;

            characterJoints[i].joint.transform.LookAt(leLookAtLh);
            characterJoints[i].joint.transform.Rotate(Vector3.up, gameObject.transform.rotation.eulerAngles.y, Space.World);

            if (networkObject != null)
            {
              networkObject.leftElbowRotation = characterJoints[i].joint.transform.rotation;
            }

            break;

          case (int)JOINT_NAME.RightShoulder:
            // Find the local vector of the kinect Left Shoulder to Left Elbow
            Vector3 rsToRe = kinectJoint[(int)JOINT_NAME.RightElbow].jointPos - kinectJoint[i].jointPos;
            rsToRe.z *= -1;
            Vector3 rsLookAtRe = characterJoints[i].joint.transform.position + rsToRe;

            characterJoints[i].joint.transform.LookAt(rsLookAtRe);
            characterJoints[i].joint.transform.Rotate(Vector3.up, gameObject.transform.rotation.eulerAngles.y, Space.World);

            if (networkObject != null)
            {
              networkObject.rightShoulderRotation = characterJoints[i].joint.transform.rotation;
            }

            break;

          case (int)JOINT_NAME.RightElbow:
            // Find the local vector of the kinect Left Shoulder to Left Elbow
            Vector3 reToRh = kinectJoint[(int)JOINT_NAME.RightHand].jointPos - kinectJoint[i].jointPos;
            reToRh.z *= -1;
            Vector3 reLookAtRh = characterJoints[i].joint.transform.position + reToRh;

            characterJoints[i].joint.transform.LookAt(reLookAtRh);
            characterJoints[i].joint.transform.Rotate(Vector3.up, gameObject.transform.rotation.eulerAngles.y, Space.World);

            if (networkObject != null)
            {
              networkObject.rightElbowRotation = characterJoints[i].joint.transform.rotation;
            }

            break;
        }
      }
    }
  }
}
