using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTypeButton : MonoBehaviour
{
    public GameObject vertLayoutWithTowers;

    public bool isChildEnabled;
    // Start is called before the first frame update
    void Start()
    {
        isChildEnabled = false;
    }
    
    public void OnTypeClick()
    {
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
