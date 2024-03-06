using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyWave[] waves;
    public AnimationCurve curve;
    public TrackPoint startPoint;
    public Enemy lastEnemyOfGame;
    private bool wavesDone;

    public GameEndScreens endgameScreens;
    public TransitionManager transitionManager;
    public Coroutine spawnCR;

    public int currentWave;

    // Start is called before the first frame update
    void Start()
    {
        wavesDone = false;
            waves[currentWave].startPoint = startPoint;
            waves[currentWave].spawner = this;
         waves[currentWave].transitionManager = transitionManager;
        waves[currentWave].spawnCR = StartCoroutine(waves[currentWave].Spawn_CR());
    }


    public void Update()
    {
        if (wavesDone)
        {
            if(lastEnemyOfGame == null)
            {
                endgameScreens.OpenWinScreen();
            }
        }

    }
    public void StartNextWave()
    {
        currentWave++;
        if (currentWave < waves.Length)
        {
            waves[currentWave].startPoint = startPoint;
            waves[currentWave].spawner = this;
            waves[currentWave].transitionManager = transitionManager;
            waves[currentWave].spawnCR = StartCoroutine(waves[currentWave].Spawn_CR());
        }
        else 
        {
            wavesDone = true;
        }
        
    }
 

    public int CurrentWave()
    {
        return currentWave +1;
    }
}
