using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Health pickup collected");
        if (collision.gameObject.name.Contains("Player"))
        {
            gameManager.AddHealth();
            Destroy(this.gameObject);
        }
    }
}