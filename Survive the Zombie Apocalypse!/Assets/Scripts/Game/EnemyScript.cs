using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    Coroutine playerCollide;
    protected float damage, speed;
    public GameObject player;
    public GameManager _gameManager;

    public GameObject Player {
        get { return player; }
        set { player = value; } 
    }

    public GameManager gameManager
    {
        get { return _gameManager; }
        set { _gameManager = value; }
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        try
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, 0f), speed * Time.deltaTime);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e + "is null");
        }
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
            if (playerCollide != null) StopCoroutine(playerCollide);

            else
            {
                StopCoroutine(DamagePlayer());
            }
        }
    }

    IEnumerator DamagePlayer()
    {
        while (true)
        {
            Debug.Log("Player Hit");
            gameManager.PlayerDamage(damage);
            yield return new WaitForSeconds(1f);
        }
    }
}