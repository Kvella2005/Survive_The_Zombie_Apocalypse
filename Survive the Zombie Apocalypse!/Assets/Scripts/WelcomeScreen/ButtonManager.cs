using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public List<Button> buttons;
    SaveGame saveGame;

    // Start is called before the first frame update
    void Start()
    {
        saveGame = GameObject.Find("SaveManager").GetComponent<SaveGame>();
        foreach (var button in buttons)
        {
            // Assuming button names are "Start" and "Exit" for respective functionality
            if (button.name == "Continue")
            {
                button.onClick.AddListener(ContinueGame);
            }

            if (button.name == "New Game")
            {
                button.onClick.AddListener(StartGame);
            }

            if (button.name == "Exit")
            {
                button.onClick.AddListener(QuitGame);
            }

            // Add a generic listener for all buttons
            if (button.IsActive() == true)
            {
                button.onClick.AddListener(() => printMessage(button.name));
            }
        }
    }

    void ContinueGame()
    {
        //loads save
        Debug.Log("You have clicked continue button");
        saveGame.Load();
        saveGame.LoadLevel();
    }

    void StartGame()
    {
        Debug.Log("You have clicked the start button");
        SceneManager.LoadScene("Level1");
    }

    void QuitGame()
    {
        Debug.Log("You have clicked the exit button");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#else
        Application.Quit();
#endif
    }

    void printMessage(string buttonName)
    {
        Debug.Log("Event on" + buttonName + "is added");
    }

}
