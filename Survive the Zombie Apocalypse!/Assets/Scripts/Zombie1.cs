using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1 : EnemyScript
{
    [SerializeField] EnemySO enemyAttributes;

    // Start is called before the first frame update
    void Start()
    {
        damage = enemyAttributes.damage;
        speed = enemyAttributes.speed;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
