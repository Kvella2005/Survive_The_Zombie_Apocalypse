using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    Coroutine playerCollide;
    protected float damage, speed;
    public GameObject player;

    public GameObject Player {
        get { return player; }
        set { player = value; } 
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, 0f), speed * Time.deltaTime);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //when the enemy is now colliding with the player
        if (collision.gameObject.name.Contains("Player"))
        {
            if(playerCollide == null) playerCollide = StartCoroutine(DamagePlayer());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //when the enemy is no longer colliding with the player
        if (collision.gameObject.name.Contains("Player"))
        {
            //Debug.Log("collision exit");
            if (playerCollide != null) StopCoroutine(playerCollide);
        }
    }

    IEnumerator DamagePlayer()
    {
        while (true)
        {
            Debug.Log("Player Hit");
            yield return new WaitForSeconds(1f);
        }
    }
}
