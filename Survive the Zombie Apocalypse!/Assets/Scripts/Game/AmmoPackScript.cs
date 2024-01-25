using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPackScript : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            Debug.Log("Ammo pickup collected");
            gameManager.AddAmmo();
            Destroy(this.gameObject);
        }
    }
}
