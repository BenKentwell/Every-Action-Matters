using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(EnemyTransition))]
public class Enemy : MonoBehaviour
{
    public EnemyType type;
    public Vector2 direction;
    public SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = type.texture;

    }

    private void Update()
    {
        if(type.speed != 0)
        {
            transform.Translate(direction * type.speed * Time.deltaTime );
        }
    }

    public void SetValues()
    {
        renderer.sprite = type.texture;
    }
    
}
