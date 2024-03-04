using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start game!");

        SceneManager.LoadScene("2-GameplayScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");

        Application.Quit();
    }
}
