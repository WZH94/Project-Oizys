using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;
using UnityEngine;

public class CampfireSpot : CampfireSpotBehavior
{
  public GameObject spot;
  private bool spotTaken = false;

  public void PreAssignPlayer(GameObject player)
  {
    spot = player;
    spotTaken = true;
    networkObject.spotTaken = spotTaken;
    //networkObject.SendRpc(RPC_ASSIGN_PLAYER, Receivers.AllBuffered, player.ObjectToByteArray());
  }

  public bool SpotTaken()
  {
    return networkObject.spotTaken;
  }

  public override void AssignPlayer(RpcArgs args)
  {
    //byte[] playerBytes = args.GetNext<byte[]>();

    //spot = playerBytes.ByteArrayToObject<GameObject>();
  }
}
