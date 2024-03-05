using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{

    public Enemy[] enemies;
    public int[] enemyCount;
    public AnimationCurve curve;
    public TrackPoint startPoint;
    public EnemySpawner spawner;
    public TransitionManager transitionManager;
    public Coroutine spawnCR;
    public float maximumSeconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public IEnumerator Spawn_CR()
    {
        int i = 0;
        int iMax = enemies.Length;
        for(int en = 0; en < enemies.Count(); en++)
        {
            i++;
            for(int coun = 0; coun < enemyCount[en]; coun++)
            {
            yield return new WaitForSeconds(curve.Evaluate(i/iMax) * maximumSeconds);
            Enemy enemy = Instantiate(enemies[en], startPoint.transform.position, transform.rotation);
            enemy.trackPoint = startPoint.nextTrack;
            enemy.gameObject.GetComponent<EnemyTransition>().transitionManager = transitionManager;
            }
            
        }
       
       spawner.StartNextWave();
    }
}
