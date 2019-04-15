using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public string firstScene;
    public bool initializePlayersAndCams = false;

    public GameObject HUDPrefab;
    private GameObject myHUD;
    private HUDManager myHUDManager;


    private string previousScene;
    private string currentScene;

    private bool isPaused = false;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);
        

        if (firstScene == null)
        {
            Debug.Log("Error: need to set firstScene variable in GameManager.");
        }

        AsyncOperation asyncLoadLevel;
        asyncLoadLevel = SceneManager.LoadSceneAsync(firstScene);


        if (HUDPrefab != null) {
            myHUD = Instantiate(HUDPrefab);
            DontDestroyOnLoad(myHUD);
            if (myHUD == null) {
                Debug.Log("Error: Couldn't instantiate HUD");
            }
            myHUDManager = myHUD.GetComponent<HUDManager>();
            if (myHUDManager == null) {
                Debug.Log("Error: Couldn't get HUDManager component from instantiated HUD");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("ESCAPE KEY IS DOWN!");
            TogglePause();
        }
    }


    public void WinGame() {
        myHUDManager.SetMiddleText("YOU WIN!");
        Time.timeScale = .5f;
    }


    public void LoseGame()
    {
        myHUDManager.SetMiddleText("Game Over");
        Time.timeScale = .5f;
    }

    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene("blackscreen");

        previousScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(newScene);
        currentScene = newScene;
    }


    public HUDManager getHUDManager() {
        return myHUDManager;
    }


    public void TogglePause() {
        if (isPaused) {
            myHUDManager.UnpauseGame();
            Time.timeScale = 1f;
            isPaused = false;
        } else {
            myHUDManager.PauseGame();
            Time.timeScale = 0f;
            isPaused = true;
        }
    }


}
