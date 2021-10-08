// We use this namespace as it is where our GameLogicBehavior was generated
using System.Collections.Generic;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using BeardedManStudios.Forge.Networking;
using UnityEngine;

public class PlayerManager : PlayerManagerBehavior
{
  public bool enableNetwork;
  private GameObject character;

  public List<Player> otherPlayers;

  [SerializeField]
  private Campfire[] campfires;

  private void Awake()
  {
    otherPlayers = new List<Player>();
  }

  private void Start()
  {
    if (enableNetwork)
    {
      character = NetworkManager.Instance.InstantiatePlayer(PlayerPrefs.GetInt("model"), new Vector3(607, 24, 583)).gameObject;

      var controls = character.GetComponent<KinectControls>();
      GetComponent<TCPConnect>().kinectControls = controls;

      // Only set TCP Connect IP if not in local server
      if (networkObject.Owner.Ip != "127.0.0.1")
      {
        GetComponent<TCPConnect>().IP = networkObject.Owner.Ip;
      }
    }
  }

  public void Disconnect()
  {
    character.GetComponent<PlayerBehavior>().networkObject.Destroy();

    NetworkManager.Instance.Disconnect();
  }

  public void SetControls(bool active)
  {
    if (character)
    {
      character.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.lockCursor = active;
      character.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = active;
    }
  }

  public void AddPlayer(Player newPlayer)
  {
    if (!otherPlayers.Contains(newPlayer))
    {
      otherPlayers.Add(newPlayer);
    }
  }

  public void RemovePlayer(Player destroyedPlayer)
  {
    if (otherPlayers.Contains(destroyedPlayer))
    {
      otherPlayers.Remove(destroyedPlayer);
    }
  }

  public void Empty()
  {

  }

  public void ForceCampfire()
  {
    //int campfireIndex = Random.Range(0, campfires.Length - 1);

    networkObject.SendRpc(RPC_FORCE_CAMPFIRE_SESSION, Receivers.All, 1);
  }

  // Override the abstract RPC method that we made in the NCW
  public override void ForceCampfireSession(RpcArgs args)
  {
    character.GetComponent<Player>().EnterCampfire(campfires[args.GetNext<int>()]);
  }
}