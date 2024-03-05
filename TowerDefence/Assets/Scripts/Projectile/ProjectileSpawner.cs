using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;



public class ProjectileSpawner : MonoBehaviour
{
    public void ShootNew(Tower _tower, Enemy _enemy)  
    {
       // float angle = Vector2.Angle(_tower.transform.position, _enemy.transform.position);
        Vector2 dir = _tower.transform.position - _enemy.transform.position;
        dir.Normalize();

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle -90, Vector3.forward);

        GameObject porj = Instantiate(_tower.projectileObject, _tower.transform.position, q);
        porj.GetComponent<ProjectileObject>().SetEndPoint(_enemy.transform.position);
        porj.GetComponent<SpriteRenderer>().sortingOrder = 101;
        

    }
}
