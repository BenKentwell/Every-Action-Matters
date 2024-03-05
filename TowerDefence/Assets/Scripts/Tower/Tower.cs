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
    public TowerManager towerManager;
    public bool isEnabledToShoot;

    // Start is called before the first frame update
    void Start()
    {
        projectileSpawner = GameObject.FindWithTag("ProjectileSpawner").GetComponent<ProjectileSpawner>();
        towerManager = GameObject.FindWithTag("ProjectileSpawner").GetComponent<TowerManager>();
        
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
        towerManager.AddTower(this);
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
            if(enemiesWithinRange.Count > 0 && isEnabledToShoot)
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
            switch((int)spread)
            {
                case (int)eSpread.Direct:
                    _enemy.gameObject.GetComponent<EnemyTransition>().Break(damageType);
                    enemiesWithinRange.Remove(_enemy);
                break;

                case (int)eSpread.Artillery:
                     Collider2D[] results = new Collider2D[7];
                     ContactFilter2D filter2D = new ContactFilter2D();
                     filter2D.NoFilter();
                    int objects = Physics2D.OverlapCircle(_enemy.transform.position, 0.5f,filter2D, results );
                    if(objects > 0)
                    {
                        for(int i = 0; i < objects; i++)
                        {   
                            if(results[i].gameObject.GetComponent<Enemy>())
                            {
                                results[i].gameObject.GetComponent<EnemyTransition>().Break(damageType);
                                if(enemiesWithinRange.Contains(results[i].gameObject.GetComponent<Enemy>()))
                                    enemiesWithinRange.Remove(results[i].gameObject.GetComponent<Enemy>());
                            }
                            
                        }
                    }
                break;

                case (int)eSpread.Spread:
                    int max = 8;
                    if(max > enemiesWithinRange.Count -1)
                        max = enemiesWithinRange.Count -1;
                    for(int i = max; i >= 0; i--)
                    {
                        enemiesWithinRange[i].gameObject.GetComponent<EnemyTransition>().Break(damageType);
                        enemiesWithinRange.Remove(enemiesWithinRange[i].gameObject.GetComponent<Enemy>());
                    }
                    Debug.Log($"spread shot {max} babooshkas");

                break;

            }
            
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
    public void SetShooting(bool _bool)
    {
        isEnabledToShoot = _bool;
        if(!_bool)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        }

    }
    

}
