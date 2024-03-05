using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public uint startHealth = 100;
    
    public static int health;
    private static bool hasChanged = false;
    [SerializeField] private Text healthCounter;

    private DeathScreen deathScreen;

    void Start()
    {
        health = (int)startHealth;
        
        healthCounter.text = health.ToString();

        deathScreen = FindObjectOfType<DeathScreen>();
    }

    void Update()
    {
        if (hasChanged)
        {
            hasChanged = false;

            healthCounter.text = health.ToString();

            if (health == 0)
            {
                Time.timeScale = 0f;
                deathScreen.OpenDeathScreen();
            }
        }
    }

    public static void DecrementHealth(EnemyType givenType)
    {
        health -= givenType.type;

        if (health < 0)
            health = 0;

        hasChanged = true;
    }
}
