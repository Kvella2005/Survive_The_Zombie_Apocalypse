using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    protected float WaitSeconds = 1f;
    protected Coroutine shootBulletCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootBulletCoroutine = StartCoroutine(shootBullet(WaitSeconds, bullet));
        }

        else if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(shootBulletCoroutine);
        }
    }

    IEnumerator shootBullet(float secs, GameObject bullet)
    {
        while (true)
        {
            //bullet.transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.y));
            Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(secs);
        }
    }
}
