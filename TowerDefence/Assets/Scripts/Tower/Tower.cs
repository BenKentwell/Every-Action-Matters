using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;


public enum eSpread
{
    Tack = 1,
    Dart, 
    Bomb
}

public class Tower : MonoBehaviour
{
    public ProjectileObject projectileObject;
    public ProjectileSpawner projectileSpawner;
    public float shootDelay = 1;
    public eSpread spread;

    public Coroutine shootCR;
    // Start is called before the first frame update
    void Start()
    {
        shootCR = StartCoroutine(Shoot_CR());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Shoot_CR()
    {
        while(true)
        {
            yield return new WaitForSeconds(shootDelay);
            SetDirection();
            //SetRotation
            Shoot();
        }
    }

    public void Shoot()
    {
        projectileSpawner.ShootNew(transform, spread, projectileObject);
    }
    private void SetDirection()
    {
      //  Vector2 diff = new Vector2(transform.position.x - Input.mousePosition.y, transform.position.y );
        float angle = Vector2.Angle(new Vector2(Input.mousePosition.x, Input.mousePosition.y),new Vector2(transform.position.x, transform.position.y) );
        
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
}
