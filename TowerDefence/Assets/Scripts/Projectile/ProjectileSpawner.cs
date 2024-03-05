using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class ProjectileSpawner : MonoBehaviour
{
    public void ShootNew(Tower _tower, Enemy _enemy)  
    {
        switch(_tower.spread)
        {
            case eSpread.Direct:
                float angle = Vector2.SignedAngle(_tower.transform.position, _enemy.transform.position);

                Quaternion q = Quaternion.identity;
                GameObject porj = Instantiate(_tower.projectileObject, _tower.transform.position, q);
                porj.transform.Rotate(0, 0, angle);

                porj.GetComponent<ProjectileObject>().SetEndPoint(_enemy.transform.position);
                porj.GetComponent<SpriteRenderer>().sortingOrder = 101;
            break;

            case eSpread.Spread:
                

                Quaternion qu = Quaternion.FromToRotation(_tower.transform.position, _enemy.transform.position);
                GameObject porju = Instantiate(_tower.projectileObject, _tower.transform.position, qu);
                porju.GetComponent<ProjectileObject>().SetEndPoint(_enemy.transform.position);
                porju.GetComponent<SpriteRenderer>().sortingOrder = 101;
            break;

        }
    }
}
