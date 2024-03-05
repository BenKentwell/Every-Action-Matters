using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static int health = 20;
    private static bool hasChanged = false;
    [SerializeField] private Text healthCounter;

    void Start()
    {
        healthCounter.text = health.ToString();
    }

    void Update()
    {
        if (hasChanged)
        {
            hasChanged = false;

            healthCounter.text = health.ToString();

            if (health == 0)
            {
                Debug.Log("You dead!");
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
