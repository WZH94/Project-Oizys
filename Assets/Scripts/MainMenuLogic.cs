using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuLogic : MonoBehaviour
{
  private readonly Vector3 MENU_CAM_POS = new Vector3(0, 1f, -10f);
  private readonly Vector3 MENU_CAM_ROT = new Vector3();
  private readonly Vector3 AVATAR_CAM_POS = new Vector3(0.6f, 2.1f, -8.5f);
  private readonly Vector3 AVATAR_CAM_ROT = new Vector3(11.254f, 13.094f);

  private bool inAvatarMenu = false;
  private const float LERP_TIME = 0.7f;
  private const float MENU_OFFSCREEN_POS = 1920f * 1.5f;

  private readonly Vector3 SHOWCASE_POS = new Vector3(1.84f, -0.502f, -4.96f);
  private readonly Vector3 SHOWCASE_ROT = new Vector3(0, -166.906f, 0);

  [SerializeField]
  public RectTransform mainMenu, avatarMenu;
  [SerializeField]
  public Camera mainCamera;
  [SerializeField]
  private TCPConnect tcpConnect;

  private PlayerModels playerModels;

  private GameObject modelShowcase;

  private int currentModel;

  private void Start()
  {
    playerModels = GetComponent<PlayerModels>();

    currentModel = PlayerPrefs.GetInt("model");

    InstantiateModel();
  }

  public void StartGame()
  {
    SceneManager.LoadScene("MultiplayerMenu");
  }

  public void CustomiseAvatar()
  {
    inAvatarMenu = !inAvatarMenu;

    StopAllCoroutines();

    BeginLerpCamera();
    BeginLerpMenu();
  }

  private Coroutine BeginLerpCamera()
  {
    if (inAvatarMenu)
    {
      return StartCoroutine(LerpCamera(AVATAR_CAM_POS, AVATAR_CAM_ROT));
    }

    else
    {
      return StartCoroutine(LerpCamera(MENU_CAM_POS, MENU_CAM_ROT));
    }
  }


  private IEnumerator LerpCamera(Vector3 destPos, Vector3 destRot)
  {
    float startTime = Time.time;

    Vector3 fromPos = mainCamera.transform.position;
    Vector3 fromRot = mainCamera.transform.rotation.eulerAngles;

    while (Time.time - startTime < LERP_TIME)
    {
      mainCamera.transform.position = Vector3.Lerp(fromPos, destPos, (Time.time - startTime) / LERP_TIME);
      mainCamera.transform.eulerAngles = Vector3.Lerp(fromRot, destRot, (Time.time - startTime) / LERP_TIME);

      yield return 1;
    }

    mainCamera.transform.position = destPos;
    mainCamera.transform.eulerAngles = destRot;
  }

  private Coroutine BeginLerpMenu()
  {
    return StartCoroutine(LerpMenu());
  }


  private IEnumerator LerpMenu()
  {
    float startTime = Time.time;

    float mainMenuFromPos = mainMenu.anchoredPosition.x;
    float avatarMenuFromPos = avatarMenu.anchoredPosition.x;

    float mainMenuDestPos = 0;
    float avatarMenuDestPos = 0;

    if (inAvatarMenu)
    {
      mainMenuDestPos = -MENU_OFFSCREEN_POS;
    }

    else
    {
      avatarMenuDestPos = MENU_OFFSCREEN_POS;
    }

    while (Time.time - startTime < LERP_TIME)
    {
      mainMenu.anchoredPosition = new Vector2(Mathf.Lerp(mainMenuFromPos, mainMenuDestPos, (Time.time - startTime) / LERP_TIME), 0);
      avatarMenu.anchoredPosition = new Vector2(Mathf.Lerp(avatarMenuFromPos, avatarMenuDestPos, (Time.time - startTime) / LERP_TIME), 0);

      yield return 1;
    }

    mainMenu.anchoredPosition = new Vector2(mainMenuDestPos, 0);
    avatarMenu.anchoredPosition = new Vector2(avatarMenuDestPos, 0);
  }

  public void SwitchModel(int num)
  {
    currentModel += num;

    if (currentModel > (int)MODEL_TYPE.ALIEN)
    {
      currentModel = 0;
    }

    else if (currentModel < 0)
    {
      currentModel = (int)MODEL_TYPE.ALIEN;
    }

    PlayerPrefs.SetInt("model", currentModel);
    PlayerPrefs.Save();

    InstantiateModel();
  }

  private void InstantiateModel()
  {
    if (modelShowcase)
    {
      Destroy(modelShowcase);
    }

    modelShowcase = Instantiate(playerModels.GetModel(currentModel));

    modelShowcase.transform.position = SHOWCASE_POS;
    modelShowcase.transform.rotation = Quaternion.Euler(SHOWCASE_ROT);
    modelShowcase.transform.localScale = Vector3.one * 0.65f;
    modelShowcase.GetComponent<Animator>().SetBool("inMenu", true);
    //modelShowcase.GetComponent<KinectControls>().enabled = false;
    modelShowcase.GetComponent<Player>().enabled = false;
    modelShowcase.GetComponent<AudioSource>().enabled = false;
    modelShowcase.GetComponentInChildren<TextMeshPro>().enabled = false;
    Destroy(modelShowcase.GetComponentInChildren<Camera>().gameObject);
    tcpConnect.kinectControls = modelShowcase.GetComponent<KinectControls>();
  }

  public void ExitGame()
  {
    Application.Quit();
  }
}
