using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    [SerializeField] List<EnemySO> enemySOs = new List<EnemySO>();
    [SerializeField] List<Transform> spawnTargets = new List<Transform>();
    [SerializeField] GameObject player;
    [SerializeField] GameManager gm;
    int enemyChoice, spawnChoice;
    [SerializeField]int maxLimit;
    GameObject tmp;
    // Start is called before the first frame update

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        for (int x = 0; x < maxLimit; x++)
        {
            enemyChoice = Random.Range(0, enemySOs.Count);
            spawnChoice = Random.Range(0, spawnTargets.Count);

            switch (enemyChoice)
            {
                case 0:
                    //spawn enemy 1
                    tmp = enemySOs[enemyChoice].enemyObject;
                    Instantiate(tmp, spawnTargets[spawnChoice].transform.position, transform.rotation);
                    tmp.transform.position = spawnTargets[spawnChoice].position;
                    tmp.GetComponent<Zombie1>().Player = player.gameObject;
                    tmp.GetComponent<Zombie1>().gameManager = gm;
                    break;

                case 1:
                    //spawn enemy 2
                    tmp = enemySOs[enemyChoice].enemyObject;
                    Instantiate(tmp, spawnTargets[spawnChoice].transform.position, transform.rotation);
                    tmp.transform.position = spawnTargets[spawnChoice].position;
                    tmp.GetComponent<Zombie2>().Player = player.gameObject;
                    tmp.GetComponent<Zombie2>().gameManager = gm;
                    break;

                default:
                    Debug.Log("Enemy " +  enemyChoice + "doesn't exist");
                    break;
            }
        }
    }
}