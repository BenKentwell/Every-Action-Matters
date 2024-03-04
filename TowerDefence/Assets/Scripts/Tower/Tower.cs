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

    public Transform target;

    public Coroutine shootCR;
    // Start is called before the first frame update
    void Start()
    {
        shootCR = StartCoroutine(Shoot_CR());
    }

    // Update is called once per frame
    void Update()
    {
        SetDirection();
    }

    public IEnumerator Shoot_CR()
    {
        while(true)
        {
            yield return new WaitForSeconds(shootDelay);
            
            //SetRotation
            Shoot();
        }
    }

    public void Shoot()
    {

        //This needs to find the object that is furtherst along the track;

        projectileSpawner.ShootNew(transform, spread, projectileObject);
    }
    private void SetDirection()
    {
        Vector2 diff = new Vector2(transform.position.x - target.position.x  ,transform.position.y - target.position.y );
        diff.Normalize();
        float angle = Mathf.Atan2(diff.y, diff.x);
        angle *= Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }
}
