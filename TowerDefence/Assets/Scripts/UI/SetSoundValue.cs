using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetSoundValue : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string audioType;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        
        audioMixer.GetFloat(audioType, out float soundValue);
        slider.value = soundValue;
    }

    public void SetSound()
    {
        float soundLevel = slider.value;
        audioMixer.SetFloat(audioType, soundLevel);
    }
}
