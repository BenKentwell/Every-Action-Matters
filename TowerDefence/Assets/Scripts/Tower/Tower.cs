using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;


public enum eSpread
{
    Spread = 1,
    Direct, 
    Artillery
}


[RequireComponent(typeof(SpriteRenderer))]
public class Tower : MonoBehaviour
{
    public Sprite spriteSpreadBerf;
    public Sprite spriteDirectBerf;
    public Sprite spriteArtilleryBerf;
     public Sprite spriteSpreadBartillery;
    public Sprite spriteDirectBartillery;
    public Sprite spriteArtilleryBartillery;
     public Sprite spriteSpreadBuplo;
    public Sprite spriteDirectBuplo;
    public Sprite spriteArtillerybuplo;


    public GameObject projectileObject;
    public ProjectileSpawner projectileSpawner;
    public float shootDelay = 1;
    public eSpread spread;
    public eVulType damageType;
    public Transform target;
    public Coroutine shootCR;
    public float viewDistanceRadius = 2;

    public List<Enemy> enemiesWithinRange = new();

    // Start is called before the first frame update
    void Start()
    {
        projectileSpawner = GameObject.FindWithTag("ProjectileSpawner").GetComponent<ProjectileSpawner>();
        GetComponent<CircleCollider2D>().radius = viewDistanceRadius;
        if(spread == eSpread.Spread && damageType == eVulType.Berf)
            GetComponent<SpriteRenderer>().sprite = spriteSpreadBerf;
        if(spread == eSpread.Spread && damageType == eVulType.Billitary)
            GetComponent<SpriteRenderer>().sprite = spriteSpreadBartillery;
        if(spread == eSpread.Spread && damageType == eVulType.Buplo)
            GetComponent<SpriteRenderer>().sprite = spriteSpreadBuplo;

        if(spread == eSpread.Direct && damageType == eVulType.Berf)
            GetComponent<SpriteRenderer>().sprite = spriteDirectBerf;
        if(spread == eSpread.Direct && damageType == eVulType.Billitary)
            GetComponent<SpriteRenderer>().sprite = spriteDirectBartillery;
        if(spread == eSpread.Direct && damageType == eVulType.Buplo)
            GetComponent<SpriteRenderer>().sprite = spriteDirectBuplo;

        if(spread == eSpread.Artillery && damageType == eVulType.Berf)
            GetComponent<SpriteRenderer>().sprite = spriteArtilleryBerf;
        if(spread == eSpread.Artillery && damageType == eVulType.Billitary)
            GetComponent<SpriteRenderer>().sprite = spriteArtilleryBartillery;
        if(spread == eSpread.Artillery && damageType == eVulType.Buplo)
            GetComponent<SpriteRenderer>().sprite = spriteArtillerybuplo;    

            
       
        GetComponent<SpriteRenderer>().sortingOrder = 100;
        shootCR = StartCoroutine(Shoot_CR());
    }

    // Update is called once per frame
    void Update()
    {
       // SetDirection();
        //Debug.Log(enemiesWithinRange.Count);
    }

    public IEnumerator Shoot_CR()
    {
        while(true)
        {
            yield return new WaitForSeconds(shootDelay);
            if(enemiesWithinRange.Count > 0)
            {
                Enemy furthest = enemiesWithinRange[0];
                for(int i = 1; i < enemiesWithinRange.Count; i++)
                {
                    Enemy current = enemiesWithinRange[i];
                    if(current.trackPoint.trackNumber >= furthest.trackPoint.trackNumber)
                    {
                        if(Vector2.Distance(current.transform.position, current.trackPoint.nextTrack.transform.position)
                             < Vector2.Distance(furthest.transform.position, furthest.trackPoint.nextTrack.transform.position))
                        {
                            furthest = current;
                        }
                    }
                }

                Shoot(furthest);
            }
        }
    }

    public void Shoot(Enemy _enemy)
    {
        //This needs to find the object that is furtherst along the track, pop it and send a sprite in the direction
        if(_enemy != null)
        {
            projectileSpawner.ShootNew(this, _enemy);
            _enemy.gameObject.GetComponent<EnemyTransition>().Break(damageType);
            enemiesWithinRange.Remove(_enemy);
        }


    }
    private void SetDirection()
    {
        Vector2 diff = new Vector2(transform.position.x - target.position.x  ,transform.position.y - target.position.y );
        diff.Normalize();
        float angle = Mathf.Atan2(diff.y, diff.x);
        angle *= Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Enemy e = other.gameObject.GetComponent<Enemy>();
        if(e != null)
        {
            if(!enemiesWithinRange.Contains(e))
                enemiesWithinRange.Add(e);
        }
    }

     private void OnTriggerExit2D(Collider2D other)
    {
        Enemy e = other.gameObject.GetComponent<Enemy>();
        if(e != null)
        {
            if(enemiesWithinRange.Contains(e))
                enemiesWithinRange.Remove(e);
        }
    }
    

}
