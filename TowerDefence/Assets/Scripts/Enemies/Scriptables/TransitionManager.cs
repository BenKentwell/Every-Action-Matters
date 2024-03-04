using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public EnemyType[] types;

    public EnemyType GetType(int _i)
    {
        foreach(EnemyType t in types)
        {
            if(_i == t.type) 
            {
                return t;
            }
        }
        return null;
    }

}
