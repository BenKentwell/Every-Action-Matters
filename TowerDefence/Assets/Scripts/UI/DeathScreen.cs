using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class DeathScreen : MonoBehaviour
{
    public GameObject gameplayUI;
    public GameObject deathTab;

    public Text deathText;
    private EnemySpawner enemySpawner;

    public AudioMixer musicMixer;

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        
        gameplayUI.SetActive(true);
        deathTab.SetActive(false);

        musicMixer.SetFloat("MusicLowpass", 22000.00f);
    }

    public void OpenDeathScreen()
    {
        Debug.Log("Death!");

        gameplayUI.SetActive(false);
        deathTab.SetActive(true);

        string deathMessage = deathText.text.Replace("<Num>", enemySpawner.CurrentWave().ToString());

        deathText.text = deathMessage;

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
