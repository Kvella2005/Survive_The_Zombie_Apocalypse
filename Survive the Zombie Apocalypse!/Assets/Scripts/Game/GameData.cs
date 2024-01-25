using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameData : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private static int GameScore;
    private static float health = 100;
    private static string sceneName;
    private static int ammoAmount = 120;
    private static float ammoTime = 2f;

    public static int AmmoAmount
    {
        get { return ammoAmount; }
        set { ammoAmount = value; }
    }

    public static float AmmoTime
    {
        get { return ammoTime; }
    }

    public static string SceneName
    {
        get { return sceneName; }
        set { sceneName = value; }
    }

    public static int gameScore
    {
        get { return GameScore; }
        set { GameScore = value; }
    }

    public static float PlayerHealth
    {
        get { return health; }
        set { health = value; }
    }
}
