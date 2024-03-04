using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;


[CreateAssetMenu(fileName = "Tower", menuName = "Projectile", order = 1)]
public class Projectile : ScriptableObject
{
    public int damageType;
    [Tooltip("Speed per second the bullet  will move")]public float speed;
    [Tooltip("Scalar value , 0 to Infinity")]public int size;
    public Sprite texture;
}
