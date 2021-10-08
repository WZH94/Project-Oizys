using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
  private bool active;

  [SerializeField]
  public Button resume, settings, exit;

  [SerializeField]
  public PlayerManager playerManager;

  private void Start()
  {
    resume.onClick.AddListener(ResumeGame);
    settings.onClick.AddListener(Settings);
    exit.onClick.AddListener(ExitGame);

    active = gameObject.activeSelf;

    if (active)
    {
      ToggleActive();
    }
  }

  public void ToggleActive()
  {
    active = !active;

    playerManager.SetControls(!active);
    gameObject.SetActive(active);
  }

  private void ResumeGame()
  {
    ToggleActive();
  }

  private void Settings()
  {

  }

  private void ExitGame()
  {
    playerManager.Disconnect();

    // Goes back to main menu
    SceneManager.LoadScene("MainMenu");
  }
}
