using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    int enemyCount = 0;
    [SerializeField] ObjectPooling enemiesPool;
    bool killStreak;

    [SerializeField] TextMeshPro healthText;
    [SerializeField] TextMeshPro scoreText;

    public void PlayerDamage(float enemyDamage)
    {
        GameData.PlayerHealth -= enemyDamage;

        if(GameData.gameScore <= 0)
        {
            GameData.gameScore = 0;
        }

        else
        {
            GameData.gameScore -= (int)enemyDamage;
        }

        //mySaveLoadManager.SaveData();
        healthText.text = "Health: " + GameData.PlayerHealth.ToString();
        if (GameData.PlayerHealth <= 0)
        {
            //mySaveLoadManager.DeleteFile();
            //SceneManager.LoadScene("GameOver");
        }

        /*else if (enemyCount == 35)
        {

        }*/
    }

    public void EnemyKill()
    {
        GameData.gameScore += 10;
        scoreText.text = "Score: " + GameData.gameScore.ToString();
    }
}
