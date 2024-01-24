using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    float movementSpeed = 10f;
    Vector2 movementDirection;
    bool move;
    Animator animator;
    Coroutine playerCollide;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Move()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = movementDirection * movementSpeed;

        if(rb.velocity.magnitude > 0)
        {
            move = true;
        }

        else
        {
            move = false;
        }
    }
    /*protected virtual void OnCollisionEnter2D(Collision2D collision)
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
    }*/
}
