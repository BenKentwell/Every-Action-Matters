using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyTransition : MonoBehaviour
{

    public TransitionManager transitionManager;

private void Update()
{
    if(Input.GetKeyDown(KeyCode.Space))
    {
         GetComponent<Enemy>().type = transitionManager.GetType(GetComponent<Enemy>().type.typeToTransition);
            GetComponent<Enemy>().SetValues();
    }
}
   public void OnCollision2DEnter(Collider2D _collider2D)
   {
    Projectile projectile = _collider2D.GetComponent<Projectile>();
    if(projectile != null)
        {
            if(GetComponent<Enemy>().type.vulnerableType == eVulType.All)
            {
                GetComponent<Enemy>().type = transitionManager.GetType(GetComponent<Enemy>().type.typeToTransition);
                GetComponent<Enemy>().SetValues();
            }
           
        }

    }

    public void Break(eVulType _damageType)
    {
         Enemy thisEnemy = GetComponent<Enemy>();
            if(thisEnemy.type.vulnerableType == eVulType.All || thisEnemy.type.vulnerableType == _damageType)
            {
                EnemyType t = transitionManager.GetType(thisEnemy.type.typeToTransition);
                 if(t == null)
                 {
                    Destroy(gameObject);
                    return;
                 }
                    
                thisEnemy.type = t;
                thisEnemy.SetValues();
                return;
            }
           
        
    }
}
