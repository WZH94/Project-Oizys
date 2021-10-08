using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
  private Button button;

  private void Awake()
  {
    button = GetComponent<Button>();
    button.onClick.AddListener(ReturnToMainMenu);
  }

  private void ReturnToMainMenu()
  {
    SceneManager.LoadScene(0);
  }
}
