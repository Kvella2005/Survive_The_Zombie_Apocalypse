using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] protected GameObject Player;
    Coroutine playerCollide;
    protected float damage, speed;

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y, 0f), speed * Time.deltaTime);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            playerCollide = StartCoroutine(DamagePlayer());
        }

        //StopCoroutine(playerCollide);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StopCoroutine(playerCollide);
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
