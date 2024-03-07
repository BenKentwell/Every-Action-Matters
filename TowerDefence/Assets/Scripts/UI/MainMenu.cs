using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject tutorialTab;
    [SerializeField] private GameObject settingsTab;


    public void Start()
    {
        CloseTutorial();
        CloseSettings();
    }

    public void StartGame()
    {
        Debug.Log("Start game!");

        SceneManager.LoadScene("2-GameplayScene");
    }

    public void OpenTutorial()
    {
        mainMenu.SetActive(false);
        tutorialTab.SetActive(true);
    }

    public void CloseTutorial()
    {
        mainMenu.SetActive(true);
        tutorialTab.SetActive(false);
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsTab.SetActive(true);
    }

    public void CloseSettings()
    {
        mainMenu.SetActive(true);
        settingsTab.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");

        Application.Quit();
    }
}
