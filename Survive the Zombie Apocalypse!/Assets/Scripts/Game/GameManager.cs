using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int enemyCount = 35;
    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;
    [SerializeField] Text ammoText;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] SaveGame saveGame;
    [SerializeField] Gun gun;
    [SerializeField] Scene nextScene;

    void Start()
    {
        healthText.text = "Health: " + GameData.PlayerHealth.ToString();
        scoreText.text = "Score: " + GameData.gameScore.ToString();
        ammoText.text = "Ammo : " + gun.ammoAmount + "/" + GameData.AmmoAmount.ToString();
    }

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

    }

    public void EnemyDamage()
    {
        GameData.gameScore += 10;

        scoreText.text = "Score: " + GameData.gameScore.ToString();

    }

    public void AddHealth()
    {
        GameData.PlayerHealth += 20;

        healthText.text = "Health: " + GameData.PlayerHealth.ToString();

    }

    public void AddAmmo()
    {
        GameData.AmmoAmount += 20;

        ammoText.text = "Ammo : " + gun.ammoAmount + "/" + GameData.AmmoAmount.ToString();
    }

    public void GetAmmo(float ammoAmount)
    {
        ammoText.text = "Ammo : " + gun.ammoAmount + "/" + GameData.AmmoAmount.ToString();
    }

    public void ReduceAmmoLimit()
    {
        GameData.AmmoAmount -= 30;
        ammoText.text = "Ammo : " + gun.ammoAmount + "/" + GameData.AmmoAmount.ToString();
    }

    public void ReduceEnemyCount()
    {
        enemyCount--;
    }

    void Update()
    {
        if (enemyCount == 0)
        {
            SceneManager.LoadScene(nextScene.name);
        }

        if (GameData.PlayerHealth <= 0)
        {
            saveGame.Delete();
            SceneManager.LoadScene("GameOver");
        }
    }
}