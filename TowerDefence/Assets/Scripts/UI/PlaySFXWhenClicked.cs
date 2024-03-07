using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySFXWhenClicked : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource soundSource;
    public AudioClip soundEffect;

    public bool playOnPointerDown = false;
    public bool playOnPointerUp = false;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (playOnPointerDown)
        {
            soundSource.PlayOneShot(soundEffect);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (playOnPointerUp)
        {
            soundSource.PlayOneShot(soundEffect);
        }
    }
}
