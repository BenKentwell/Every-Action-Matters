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
    [SerializeField] private Text healthShadow;

    private GameEndScreens gameEndScreens;

    void Start()
    {
        health = (int)startHealth;
        
        healthCounter.text = health.ToString();
        healthShadow.text = health.ToString();

        gameEndScreens = FindObjectOfType<GameEndScreens>();
    }

    void Update()
    {
        if (hasChanged)
        {
            hasChanged = false;

            healthCounter.text = health.ToString();
            healthShadow.text = health.ToString();

            if (health == 0)
            {
                gameEndScreens.OpenDeathScreen();
            }
        }
    }

    public static void DecrementHealth(EnemyType givenType)
    {
        int damage;

        switch(givenType.vulnerableType)
        {
            case eVulType.All:
                damage = (int)givenType.type;
                break;
            case eVulType.Berf:
                damage = (int)givenType.type - 8;
                break;
            case eVulType.Buplo:
                damage = (int)givenType.type - 16;
                break;
            case eVulType.Billitary:
                damage = (int)givenType.type - 24;
                break;
            default:
                damage = 0;
                Debug.LogError("Invalid Vulnerable Type for Decrement Health. Debug Immediately!");
                break;
        }

        health -= damage;

        if (health < 0)
            health = 0;

        hasChanged = true;
    }
}
