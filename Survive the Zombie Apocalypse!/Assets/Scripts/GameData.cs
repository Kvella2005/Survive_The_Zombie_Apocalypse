using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameData : MonoBehaviour
{
    private static int GameScore;
    private static float health;
    private static int coins;
    private static int killCount;

    public static int gameScore
    {
        get { return gameScore; }
        set { gameScore = value; }
    }

    public static float PlayerHealth
    {
        get { return gameScore; }
        set { PlayerHealth = value; }
    }

    public static int PlayerCoins
    {
        get { return coins; }
        set { coins = value; }
    }

    public static int PlayerKillCount
    {
        get { return killCount; }
        set { killCount = value; }
    }
}
