using UnityEngine;

public class PlayerPrefsMultiplayer : MonoBehaviour
{
  private void Awake()
  {
    if (!PlayerPrefs.HasKey("ip"))
    {
      PlayerPrefs.SetString("ip", "127.0.0.1");
    }
  }
}
