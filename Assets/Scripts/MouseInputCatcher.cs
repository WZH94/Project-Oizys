using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInputCatcher : MonoBehaviour
{
  private GameObject lastUISelected;

  private void OnLevelWasLoaded(int level)
  {
    lastUISelected = EventSystem.current.firstSelectedGameObject;

    switch (level)
    {
      case (int)SCENE_LIST.MAIN_MENU:

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        break;

      case (int)SCENE_LIST.LOBBY:

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        break;

      case (int)SCENE_LIST.GAME:

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        break;
    }
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      EventSystem.current.SetSelectedGameObject(lastUISelected);
    }

    lastUISelected = EventSystem.current.currentSelectedGameObject;
  }

  private void OnDestroy()
  {
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
  }

  public void SetSelectedGameObject(GameObject button)
  {
    lastUISelected = button;
    EventSystem.current.SetSelectedGameObject(lastUISelected);
  }
}
