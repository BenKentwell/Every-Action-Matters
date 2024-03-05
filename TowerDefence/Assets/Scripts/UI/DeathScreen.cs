using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject gameplayUI;
    public GameObject deathTab;

    void Start()
    {
        gameplayUI.SetActive(true);
        deathTab.SetActive(false);
    }

    public void OpenDeathScreen()
    {
        Debug.Log("Death!");

        gameplayUI.SetActive(false);
        deathTab.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitButton()
    {
        Time.timeScale = 1;

        Debug.Log("Exit to menu");
        SceneManager.LoadScene("1-MainMenu");
    }
}
