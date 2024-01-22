using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie2 : EnemyScript
{
    void Start()
    {
        damage = 5f;
        speed = 10f;
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
