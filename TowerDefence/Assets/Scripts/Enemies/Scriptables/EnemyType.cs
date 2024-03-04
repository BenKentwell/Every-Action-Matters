using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum eVulType
{
    All= 0,
    Fire,
    Water, 
    Earth
}
[CreateAssetMenu(fileName = "Enemy", menuName = "EnemyType", order = 1)]
public class EnemyType : ScriptableObject
{
    public int type;
    public int typeToTransition;
    public eVulType vulnerableType;
    [Tooltip("Image rendered for each enemy")]public Sprite texture;
    [Tooltip("Speed of the ememy")] public float speed;
}
