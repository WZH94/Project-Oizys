using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPreferences : MonoBehaviour
{
  public enum PRIVACY_OPTION
  {
    NO = 0,
    YES
  }

  [SerializeField]
  public InputField nameField;
  [SerializeField]
  public Toggle privacyToggle, kinectVersionToggle;
  [SerializeField]
  private bool kinectV1;

  private void Awake()
  {
    if (!PlayerPrefs.HasKey("name"))
    {
      PlayerPrefs.SetString("name", "Default");
    }

    if (!PlayerPrefs.HasKey("privacy"))
    {
      PlayerPrefs.SetInt("privacy", (int)PRIVACY_OPTION.NO);
    }

    if (!PlayerPrefs.HasKey("model"))
    {
      PlayerPrefs.SetInt("model", (int)MODEL_TYPE.MALE_RED_BLACK);
    }

    if (!PlayerPrefs.HasKey("v1"))
    {
      PlayerPrefs.SetInt("v1", Convert.ToInt32(kinectV1));
    }

    PlayerPrefs.Save();

    nameField.text = PlayerPrefs.GetString("name");
    privacyToggle.isOn = PlayerPrefs.GetInt("privacy") != 0;
    kinectV1 = kinectVersionToggle.isOn = PlayerPrefs.GetInt("v1") != 0;
  }

  private void Update()
  {
    if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Cancel"))
    {
      nameField.DeactivateInputField();
    }
  }

  public void SaveName()
  {
    PlayerPrefs.SetString("name", nameField.text);

    PlayerPrefs.Save();

    nameField.DeactivateInputField();
  }

  public void SavePrivacyOption()
  {
    if (privacyToggle.isOn)
    {
      PlayerPrefs.SetInt("privacy", 1);
    }
    
    else
    {
      PlayerPrefs.SetInt("privacy", 0);
    }

    PlayerPrefs.Save();
  }

  public void SetKinectVersion()
  {
    kinectV1 = kinectVersionToggle.isOn;
    PlayerPrefs.SetInt("v1", Convert.ToInt32(kinectVersionToggle.isOn));

    PlayerPrefs.Save();
  }
}
