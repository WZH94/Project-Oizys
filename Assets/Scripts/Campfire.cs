using UnityEngine;

public class Campfire : MonoBehaviour
{
  public CampfireSpot [] characterSpots;

  public GameObject FindFreeSpot(GameObject player)
  {
    for (int i = 0; i < characterSpots.Length; ++i)
    {
      if (!characterSpots[i].SpotTaken())
      {
        characterSpots[i].PreAssignPlayer(player);
        
        return characterSpots[i].gameObject;
      }
    }

    return null;
  }

  public GameObject TakeSpot(GameObject player, int spotIndex)
  {
    characterSpots[spotIndex].PreAssignPlayer(player);

    return characterSpots[spotIndex].gameObject;
  }
}
