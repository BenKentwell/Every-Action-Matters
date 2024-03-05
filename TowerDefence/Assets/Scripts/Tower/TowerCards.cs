using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCards : MonoBehaviour
{
    [SerializeField] private Transform cardUIParent;
    
    [Header("Card Types")]
    [SerializeField] private GameObject directButton;
    [SerializeField] private GameObject spreadButton;
    [SerializeField] private GameObject artilleryButton;

    [SerializeField] private uint cardDelaySeconds = 5;

    private List<GameObject> baseButtonSpawnPool = new();
    private List<GameObject> currentSpawnPool = new();

    private bool isActivated = true;

    void Start()
    {
        baseButtonSpawnPool = new List<GameObject> { 
            directButton, directButton, directButton,
            spreadButton, spreadButton, spreadButton,
            artilleryButton, artilleryButton, artilleryButton};

        StartCoroutine(SpawnCardDelay());
    }

    private IEnumerator SpawnCardDelay()
    {
        SpawnNewCard();

        while (isActivated)
        {
            yield return new WaitForSeconds(cardDelaySeconds);
            //if(buttonsInChest.Count < max)
            SpawnNewCard();
        }
    }
    
    private void SpawnNewCard()
    {
        if (currentSpawnPool.Count == 0)
        {
            currentSpawnPool = RandomisedBaseSpawnPool();
        }

        var newCard = Instantiate(currentSpawnPool[0], cardUIParent);

        currentSpawnPool.RemoveAt(0);
    }
    
    private List<GameObject> RandomisedBaseSpawnPool()
    {
        List<GameObject> refList = baseButtonSpawnPool;
        List<GameObject> outputList = new();
        
        for (int i = 0; i < baseButtonSpawnPool.Count - 1; i++)
        {
            int randomIndex = Random.Range(0, refList.Count);

            outputList.Add(baseButtonSpawnPool[randomIndex]);
            refList.RemoveAt(randomIndex);
        }

        return outputList;
    }
}