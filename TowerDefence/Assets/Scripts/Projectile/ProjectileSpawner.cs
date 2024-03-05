using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class ProjectileSpawner : MonoBehaviour
{
    public void ShootNew(Tower _tower, Enemy _enemy)  
    {
       // float angle = Vector2.Angle(_tower.transform.position, _enemy.transform.position);
        // Vector2 dir = _tower.transform.position - _enemy.transform.position;
        // dir.Normalize();

        // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        // GameObject porj = Instantiate(_tower.projectileObject, _tower.transform.position, q);
        // porj.GetComponent<ProjectileObject>().SetEndPoint(_enemy.transform.position);
        // porj.GetComponent<SpriteRenderer>().sortingOrder = 101;

        switch((eSpread)_tower.spread)
        {
            case eSpread.Direct:
                Quaternion q = Quaternion.FromToRotation(_tower.transform.position, _enemy.transform.position);
                GameObject porj = Instantiate(_tower.projectileObject, _tower.transform.position, q);
                porj.GetComponent<ProjectileObject>().SetEndPoint(_enemy.transform.position);
                porj.GetComponent<SpriteRenderer>().sortingOrder = 101;
            break;

            case eSpread.Spread:
                

                Quaternion qu = Quaternion.FromToRotation(_tower.transform.position, _enemy.transform.position);
                GameObject porju = Instantiate(_tower.projectileObject, _tower.transform.position, qu);
                porju.GetComponent<ProjectileObject>().SetEndPoint(_enemy.transform.position);
                porju.GetComponent<SpriteRenderer>().sortingOrder = 101;
            break;

            // case eSpread.Artillery:
            //     Quaternion q = Quaternion.FromToRotation(_tower.transform.position, _enemy.transform.position);
            //     GameObject porj = Instantiate(_tower.projectileObject, _tower.transform.position, q);
            //     porj.GetComponent<ProjectileObject>().SetEndPoint(_enemy.transform.position);
            //     porj.GetComponent<SpriteRenderer>().sortingOrder = 101;
            // break;

        }
        


        

    }
}
