using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] enemies;
    public AnimationCurve curve;
    public TrackPoint startPoint;

public TransitionManager transitionManager;
    public Coroutine spawnCR;

    // Start is called before the first frame update
    void Start()
    {
        spawnCR = StartCoroutine(Spawn_CR());    
    }

    public IEnumerator Spawn_CR()
    {
        int i = 0;
        int iMax = enemies.Length;
        foreach(Enemy e in enemies)
        {
            i++;
            yield return new WaitForSeconds(curve.Evaluate(i/iMax) * 2);
            Enemy enemy = Instantiate(e, startPoint.transform.position, transform.rotation);
            enemy.trackPoint = startPoint.nextTrack;
            enemy.gameObject.GetComponent<EnemyTransition>().transitionManager = transitionManager;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
