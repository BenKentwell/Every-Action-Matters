using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(EnemyTransition))]
public class Enemy : MonoBehaviour
{
    public EnemyType type;
    public TrackPoint trackPoint;
    
    public Vector2 direction;
    public SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = type.texture;

        SetDir();

    }

    private void Update()
    {
        if(type.speed != 0)
        {
            transform.Translate(direction * type.speed * Time.deltaTime );
            if(Vector2.Distance(transform.position, trackPoint.transform.position) < 0.1f)
            {
                 if(trackPoint.nextTrack == null)
                 {
                     //Temperarily destory enemies
                     DestroyImmediate(gameObject);
                 }

                trackPoint = trackPoint.nextTrack;
                SetDir();
            }
                
        }
    }

    public void SetValues()
    {
        renderer.sprite = type.texture;
        renderer.sortingOrder = type.type + 100;
    }

    public void SetDir()
    {
        direction = trackPoint.transform.position - transform.position;
        direction.Normalize();
    }
    
}
