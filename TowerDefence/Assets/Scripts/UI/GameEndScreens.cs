using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameEndScreens : MonoBehaviour
{
    public GameObject gameplayUI;
    public GameObject deathTab;
    public GameObject winTab;

    public Text deathText;
    private EnemySpawner enemySpawner;

    public Text winText;

    public AudioMixer musicMixer;

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        
        gameplayUI.SetActive(true);
        deathTab.SetActive(false);
        winTab.SetActive(false);

        musicMixer.SetFloat("MusicLowpass", 22000.00f);
    }

    private void Update()
    {
        Debug.LogWarning("Update in GameEndScreens is active! Disable for build!");
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenWinScreen();
        }
    }

    public void OpenDeathScreen()
    {
        Debug.Log("Death!");

        Time.timeScale = 0f;

        gameplayUI.SetActive(false);
        deathTab.SetActive(true);
        winTab.SetActive(false);

        string deathMessage = deathText.text.Replace("<Num>", enemySpawner.CurrentWave().ToString());

        deathText.text = deathMessage;

        musicMixer.SetFloat("MusicLowpass", 600.00f);
    }

    public void OpenWinScreen()
    {
        Debug.Log("Win!");

        Time.timeScale = 0f;

        gameplayUI.SetActive(false);
        deathTab.SetActive(false);
        winTab.SetActive(true);

        string winMessage = winText.text.Replace("<Num>", Health.health.ToString());

        if (Health.health <= 1)
        {
            winMessage = winMessage.Replace("hearts!", "heart.\nClose one!");
        }

        winText.text = winMessage;

        musicMixer.SetFloat("MusicLowpass", 600.00f);
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

        musicMixer.SetFloat("MusicLowpass", 22000.00f);

        Debug.Log("Exit to menu");
        SceneManager.LoadScene("1-MainMenu");
    }
}
