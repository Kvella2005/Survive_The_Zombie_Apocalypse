using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    [SerializeField] List<EnemySO> enemySOs = new List<EnemySO>();
    [SerializeField] List<Transform> spawnTargets = new List<Transform>();
    [SerializeField] GameObject player;
    int enemyChoice, spawnChoice;
    [SerializeField]int maxLimit;
    GameObject tmp;
    // Start is called before the first frame update

    void Start()
    {
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
                    break;

                case 1:
                    //spawn enemy 2
                    tmp = enemySOs[enemyChoice].enemyObject;
                    Instantiate(tmp, spawnTargets[spawnChoice].transform.position, transform.rotation);
                    tmp.transform.position = spawnTargets[spawnChoice].position;
                    tmp.GetComponent<Zombie2>().Player = player.gameObject;
                    break;

                default:
                    Debug.Log("Enemy " +  enemyChoice + "doesn't exist");
                    break;
            }
        }

        /*void Update()
        {
            enemyChoice = Random.Range(0, enemySOs.Count - 1);
            spawnChoice = Random.Range(0, spawnTargets.Count - 1);


            switch (enemyChoice)
            {
                case 0:
                    //spawn enemy 1
                    tmp = enemySOs[enemyChoice].enemyObject;
                    Instantiate(tmp, spawnTargets[spawnChoice].transform.position, transform.rotation);
                    tmp.transform.position = spawnTargets[spawnChoice].position;
                    tmp.GetComponent<Zombie1>().Player = player.gameObject;
                    break;

                case 1:
                    //spawn enemy 2
                    tmp = enemySOs[enemyChoice].enemyObject;
                    Instantiate(tmp, spawnTargets[spawnChoice].transform.position, transform.rotation);
                    tmp.transform.position = spawnTargets[spawnChoice].position;
                    break;

                default:
                    Debug.Log("Enemy " + enemyChoice + "doesn't exist");
                    break;
            }
        }*/
    }
}