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
                Quaternion q = Quaternion.identity;
                GameObject porj = Instantiate(_tower.projectileObject, _tower.transform.position, q);
                porj.GetComponent<ProjectileObject>().SetEndPoint(_enemy.transform.position);
                porj.GetComponent<SpriteRenderer>().sortingOrder = 101;
            break;

            case eSpread.Spread:
                float offset = 1.5f;
                Quaternion q1 = Quaternion.identity;
                GameObject porj1 = Instantiate(_tower.projectileObject, _tower.transform.position, q1);
                porj1.GetComponent<ProjectileObject>().SetEndPoint(_tower.transform.position + new Vector3(0, offset, 0));
                porj1.GetComponent<SpriteRenderer>().sortingOrder = 101;

                GameObject porj2 = Instantiate(_tower.projectileObject, _tower.transform.position, q1);
                porj2.GetComponent<ProjectileObject>().SetEndPoint(_tower.transform.position + new Vector3(0, -offset, 0));
                porj2.GetComponent<SpriteRenderer>().sortingOrder = 101;

                GameObject porj3 = Instantiate(_tower.projectileObject, _tower.transform.position, q1);
                porj3.GetComponent<ProjectileObject>().SetEndPoint(_tower.transform.position + new Vector3(offset, 0, 0));
                porj3.GetComponent<SpriteRenderer>().sortingOrder = 101;


                GameObject porj4 = Instantiate(_tower.projectileObject, _tower.transform.position, q1);
                porj4.GetComponent<ProjectileObject>().SetEndPoint(_tower.transform.position + new Vector3(-offset, 0, 0));
                porj4.GetComponent<SpriteRenderer>().sortingOrder = 101;

                GameObject porj5 = Instantiate(_tower.projectileObject, _tower.transform.position, q1);
                porj5.GetComponent<ProjectileObject>().SetEndPoint(_tower.transform.position + new Vector3(offset, offset, 0));
                porj5.GetComponent<SpriteRenderer>().sortingOrder = 101;

                GameObject porj6 = Instantiate(_tower.projectileObject, _tower.transform.position, q1);
                porj6.GetComponent<ProjectileObject>().SetEndPoint(_tower.transform.position + new Vector3(offset, -offset, 0));
                porj6.GetComponent<SpriteRenderer>().sortingOrder = 101;

                GameObject porj7 = Instantiate(_tower.projectileObject, _tower.transform.position, q1);
                porj7.GetComponent<ProjectileObject>().SetEndPoint(_tower.transform.position + new Vector3(-offset, offset, 0));
                porj7.GetComponent<SpriteRenderer>().sortingOrder = 101;


                GameObject porj8 = Instantiate(_tower.projectileObject, _tower.transform.position, q1);
                porj8.GetComponent<ProjectileObject>().SetEndPoint(_tower.transform.position + new Vector3(-offset,-offset, 0));
                porj8.GetComponent<SpriteRenderer>().sortingOrder = 101;
                break;
                
            case eSpread.Artillery:
                Quaternion q2 = Quaternion.identity;
                GameObject porj9 = Instantiate(_tower.projectileObject, _tower.transform.position, q2);
                porj9.GetComponent<ProjectileObject>().SetEndPoint(_enemy.transform.position);
                porj9.GetComponent<SpriteRenderer>().sortingOrder = 101;
                break;

        }
    }
}
