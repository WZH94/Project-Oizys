using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
  [SerializeField]
  public GameMenu gameMenu;

  [SerializeField]
  public Button campfireButton;
  
  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      gameMenu.ToggleActive();
    }

    if (Input.GetKeyDown(KeyCode.C))
    {
      GetComponent<PlayerManager>().ForceCampfire();
    }
  }
}
