using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    protected float WaitSeconds = 1f;
    protected Coroutine shootBulletCoroutine;
    [SerializeField] ObjectPooling bulletPool;
    [SerializeField] GameManager gm;
    Animator animator;
    public int ammoAmount = 30;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("pause menu num is 1");
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Shoot", true);
            shootBulletCoroutine = StartCoroutine(shootBullet(WaitSeconds, bullet));
        }

        else if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Shoot", false);
            StopCoroutine(shootBulletCoroutine);
        }
    }

    IEnumerator shootBullet(float secs, GameObject bullet)
    {
        while (true)
        {
            if(ammoAmount > 0){
                bullet = bulletPool.GetPooledObject();
                bullet.transform.position = this.transform.position;
                bullet.transform.rotation = this.transform.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().gameManager = gm;
                ammoAmount -= 1;
                gm.GetAmmo(ammoAmount);
                //Debug.Log(ammoAmount);
            }

            else{
                animator.SetBool("Reload", true);
                ammoAmount = 30;
                gm.ReduceAmmoLimit();
                yield return new WaitForSeconds(GameData.AmmoTime);
                animator.SetBool("Reload", false);
            }

            yield return new WaitForSeconds(secs);
        }
    }
}
