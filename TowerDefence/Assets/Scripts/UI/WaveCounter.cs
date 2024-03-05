using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    [SerializeField] private Text waveCounter;
    [SerializeField] private Text waveShadow;

    private EnemySpawner spawner;
    private string waveTotalText;

    void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>();

        waveTotalText = "/" + spawner.waves.Length;
        ReplaceTextStrings(waveTotalText);
    }

    void Update()
    {
        string update = spawner.currentWave + waveTotalText;

        ReplaceTextStrings(update);
    }

    private void ReplaceTextStrings(string text)
    {
        waveCounter.text = text;
        waveShadow.text = text;
    }
}
