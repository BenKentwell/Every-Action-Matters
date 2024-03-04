using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTransition : MonoBehaviour
{

    public TransitionManager transitionManager;

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
}
