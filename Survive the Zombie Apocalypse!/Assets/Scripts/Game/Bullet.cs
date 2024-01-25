using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    //Vector3 mousePos, direction, rotation;
    [SerializeField] GameObject blood;
    GameManager _gameManager;
    float bulletSpeed = 20f;

    public GameManager gameManager
    {
        get { return _gameManager; }
        set { _gameManager = value; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    void FixedUpdate()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            Instantiate(blood, collision.transform.position, transform.rotation);
            gameManager.EnemyDamage();
            Destroy(collision.gameObject);
            this.gameObject.SetActive(false);
            gameManager.ReduceEnemyCount();
        }
    }

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}
