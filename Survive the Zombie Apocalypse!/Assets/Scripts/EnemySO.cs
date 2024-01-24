using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]

public class EnemySO : ScriptableObject
{
    public float damage;
    public float speed;
    public GameObject enemyObject;
}
