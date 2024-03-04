using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ProjectileSpawner : MonoBehaviour
{
    public void ShootNew(Transform _tower, eSpread _spread, ProjectileObject _proj )  
    {
        switch(_spread)
        {
            case eSpread.Tack:
            GameObject.Instantiate(_proj, _tower.position, _tower.rotation);
            break;

            case eSpread.Dart:
            GameObject.Instantiate(_proj, _tower.position, _tower.rotation);
            break;

            case eSpread.Bomb:
             GameObject.Instantiate(_proj, _tower.position, _tower.rotation);
            break;
        }
    }
}
