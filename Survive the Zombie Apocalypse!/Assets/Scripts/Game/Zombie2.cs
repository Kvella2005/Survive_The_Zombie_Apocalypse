using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie2 : EnemyScript
{
    [SerializeField] EnemySO enemyAttributes;

    void Start()
    {
        damage = enemyAttributes.damage;
        speed = enemyAttributes.speed;
    }
    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
