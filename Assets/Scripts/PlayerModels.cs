using UnityEngine;

public enum MODEL_TYPE
{
  MALE_RED_BLACK = 0,
  MALE_RED_WHITE,
  MALE_PURPLE_BLACK,
  MALE_PURPLE_WHITE,
  MALE_GREEN_BLACK,
  MALE_GREEN_WHITE,
  MALE_BLACK_BLACK,
  MALE_BLACK_WHITE,
  FEMALE_RED_BLACK,
  FEMALE_RED_WHITE,
  FEMALE_PURPLE_BLACK,
  FEMALE_PURPLE_WHITE,
  FEMALE_GREEN_BLACK,
  FEMALE_GREEN_WHITE,
  FEMALE_BLACK_BLACK,
  FEMALE_BLACK_WHITE,
  ALIEN
}

public class PlayerModels : MonoBehaviour
{
  [SerializeField]
  private GameObject[] models;

  public GameObject GetModel(int modelIndex)
  {
    if (modelIndex >= 0 && modelIndex <= (int)MODEL_TYPE.ALIEN)
    {
      return models[modelIndex];
    }

    else return null;
  }
}
