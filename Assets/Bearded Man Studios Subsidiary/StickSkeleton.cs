using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class StickSkeleton : MonoBehaviour
{
    struct JointButtonPair
    {
        public GameObject controllerJoint;
        public string buttonName;
    }
    
    [SerializeField] private GameObject joints;
    [SerializeField] private GameObject linePrefab;

    private Animator _animator;

    struct BoneComponent
    {
        public LineRenderer lineRenderer;
        public Transform childTransform;
        public Transform parentTransform;
    }

    private List<BoneComponent> _boneComponents = new List<BoneComponent>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var joint in joints.GetComponentsInChildren<StickJoint>())
        {
            GameObject newBone = Instantiate(linePrefab, joint.transform);
            BoneComponent newBoneComponent = new BoneComponent();
            newBoneComponent.childTransform = joint.transform;
            newBoneComponent.parentTransform = joint.parentTransform;
            newBoneComponent.lineRenderer = newBone.GetComponent<LineRenderer>();
            _boneComponents.Add(newBoneComponent);
        }

        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var bone in _boneComponents)
        {
            //set line coords
            Vector3 childPosition = bone.childTransform.position;
            Vector3 parentPosition = bone.parentTransform.position;
            Vector3[] positions = {childPosition, parentPosition};
            bone.lineRenderer.SetPositions(positions);
        }
        
        //animator
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (Input.GetKeyDown(KeyCode.A))
            _animator.SetBool("walkingbackwards", true);
        if (Input.GetKeyUp(KeyCode.A))
            _animator.SetBool("walkingbackwards", false);
        
        if (Input.GetKeyDown(KeyCode.D))
            _animator.SetBool("walkingforwards", true);
        if (Input.GetKeyUp(KeyCode.D))
            _animator.SetBool("walkingforwards", false);
    }
}
