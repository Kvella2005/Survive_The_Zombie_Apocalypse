using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    int pauseNum = 0;
    [SerializeField] Canvas GameHUD;
    [SerializeField] Canvas PauseScreen;
    [SerializeField] List<Button> buttons;
    SaveGame saveGame;

    void Start()
    {
        SaveGame saveGame = GameObject.Find("SaveManager").GetComponent<SaveGame>();
        foreach (var button in buttons)
        {
            if (button.name == "Resume")
            {
                button.onClick.AddListener(ResumeGame);
            }

            if (button.name == "Main Menu")
            {
                button.onClick.AddListener(SaveAndGoToMainMenu);
            }

            // Add a generic listener for all buttons
            if (button.IsActive() == true)
            {
                button.onClick.AddListener(() => printMessage(button.name));
            }
        }
    }

    void ResumeGame()
    {
        GameHUD.gameObject.SetActive(true);
        PauseScreen.gameObject.SetActive(false);
        pauseNum = 2;
        Time.timeScale = 1;
    }

    void SaveAndGoToMainMenu()
    {
        saveGame.Save();
        SceneManager.LoadScene("WelcomeScreen");
    }

    void printMessage(string message)
    {
        Debug.Log(message);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseNum++;
        }
        if (pauseNum == 1)
        {
            GameHUD.gameObject.SetActive(false);
            PauseScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
            GameObject.Find("Player").GetComponent<Gun>().enabled = false;
        }

        else if(pauseNum >= 2)
        {
            GameHUD.gameObject.SetActive(true);
            PauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
            GameObject.Find("Player").GetComponent<Gun>().enabled = true;
            pauseNum = 0;
        }
    }
}