using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTypeButton : MonoBehaviour
{
    public GameObject vertLayoutWithTowers;

    public bool isChildEnabled;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        isChildEnabled = false;
        audioSource = GetComponent<AudioSource>();
    }
    
    public void OnTypeClick()
    {
        audioSource.Play();
        
        if(isChildEnabled)
        {
            isChildEnabled = false;
            vertLayoutWithTowers.gameObject.SetActive(false);
        }
        else
        {
            isChildEnabled = true;
             vertLayoutWithTowers.gameObject.SetActive(true);
        }
    }
}
