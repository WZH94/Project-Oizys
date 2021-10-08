// We use this namespace as it is where our PlayerBehavior was generated
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class Player : PlayerBehavior
{
  [SerializeField]
  public TextMeshPro floatingText;

  private Animator _animator;

  private bool setup = false;
  private bool inCampfire = false;
  private const int DISABLE_TIME = 5;
  private int disableCountdown = 0;

  // NetworkStart() is **automatically** called, when a networkObject 
  // has been fully setup on the network and ready/finalized on the network!
  // In simpler words, think of it like Unity's Start() but for the network ;)
  protected override void NetworkStart()
  {
    _animator = GetComponent<Animator>();

    base.NetworkStart();

    // If this networkObject is actually the **enemy** Player
    // hence not the one we will control and own
    if (!networkObject.IsOwner)
    {
      // Don't render through a camera that is not ours
      // Don't listen to audio through a listener that is not ours
      transform.GetChild(0).gameObject.SetActive(false);

      // Don't accept inputs from objects that are not ours
      GetComponent<FirstPersonController>().enabled = false;

      // There is no reason to try and simulate physics since 
      // the position is being sent across the network anyway
      Destroy(GetComponent<Rigidbody>());

      // Add this player to the full list of players in the PlayerManager
      FindObjectOfType<PlayerManager>().AddPlayer(this);
    }

    // Remove the player model so it does not get in the way of the camera
    //GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;

    // Assign the name when this object is setup on the network
    ChangeName();
  }

  public void ChangeName()
  {
    // Only the owning client of this object can assign the name
    if (!networkObject.IsOwner)
      return;

    // Assign the name from PlayerPrefs
    floatingText.text = PlayerPrefs.GetString("name");

    // Set whether it is enabled or not
    floatingText.enabled = PlayerPrefs.GetInt("privacy") == 0;

    // Send an RPC to let everyone know what the name is for this player
    // We use "AllBuffered" so that if people come late they will get the
    // latest name for this object
    networkObject.SendRpc(RPC_UPDATE_NAME, Receivers.AllBuffered, floatingText.text, floatingText.enabled);
  }

  // Default Unity update method
  private void Update()
  {
    // Check to see if we are NOT the owner of this player
    if (!networkObject.IsOwner)
    {
      UpdateAnimator(false);

      // Set this object's transform.position
      // to the position that is syndicated across the network
      // In simpler words, its position is updated via the network.
      transform.position = networkObject.position;
      transform.rotation = networkObject.rotation;

      Vector3 center = GetComponent<CharacterController>().center;
      center.y = networkObject.controllerCenterY;

      GetComponent<CharacterController>().center = center;

      return;
    }

    UpdateAnimator(true);

    // When our position changes, the networkObject.position 
    // will detect the change based on this assignment automatically
    // and this data will then be syndicated across the network
    // on the next update pass for this networkObject.
    // In simpler words, our local position (transform.position) is 
    // registered and shared onto the network -> see above if
    networkObject.position = transform.position;
    networkObject.rotation = transform.rotation;

    if (!setup && !GetComponent<FirstPersonController>().enabled)
    {
      if (disableCountdown < DISABLE_TIME)
      {
        ++disableCountdown;
      }

      else
      {
        GetComponent<FirstPersonController>().enabled = true;
        setup = true;
      }
    }
  }
  
  //
  private void UpdateAnimator(bool owner)
  {
    if (!owner)
    {
      _animator.SetBool("walking", networkObject.walking);
      _animator.SetBool("sitting", networkObject.walking);
    }

    else
    {
      if (!inCampfire)
      {
        if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
          _animator.SetBool("walking", false);

        else
          _animator.SetBool("walking", true);

        _animator.SetBool("sitting", false);
      }
      
      else
      {
        _animator.SetBool("walking", false);
        _animator.SetBool("sitting", true);
      }

      networkObject.walking = _animator.GetBool("walking");
      networkObject.seating = _animator.GetBool("sitting");
    }
  }

  // Override the abstract RPC method that we made in the NCW
  public override void UpdateName(RpcArgs args)
  {
    floatingText.text = args.GetNext<string>();
    floatingText.enabled = args.GetNext<bool>();
  }

  private void OnDestroy()
  {
    if (networkObject != null)
    {
      PlayerManager playerManager = FindObjectOfType<PlayerManager>();
      // Add this player to the full list of players in the PlayerManager
      if (playerManager)
      {
        playerManager.RemovePlayer(this);
      }

      networkObject.Destroy();
    }
  }

  public void EnterCampfire(Campfire campFire)
  {
    if (inCampfire)
    {
      return;
    }

    inCampfire = true;

    GetComponent<FirstPersonController>().movementDisabled = true;

    GetComponent<FirstPersonController>().enabled = false;
    disableCountdown = 0;
    setup = false;

    int spotIndex = (int)networkObject.MyPlayerId;

    Debug.Log(spotIndex);

    GameObject chosenSpot = campFire.TakeSpot(gameObject, spotIndex);

    transform.rotation = chosenSpot.transform.rotation;
    transform.position = chosenSpot.transform.position;

    Vector3 center = GetComponent<CharacterController>().center;
    center.y = 4.5f;
    GetComponent<CharacterController>().center = center;

    networkObject.rotation = transform.rotation;
    networkObject.position = transform.position;
    networkObject.controllerCenterY = center.y;
  }
}
