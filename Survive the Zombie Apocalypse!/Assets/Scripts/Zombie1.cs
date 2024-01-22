using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1 : EnemyScript
{

    // Start is called before the first frame update
    void Start()
    {
        damage = 15f;
        speed = 5f;
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
