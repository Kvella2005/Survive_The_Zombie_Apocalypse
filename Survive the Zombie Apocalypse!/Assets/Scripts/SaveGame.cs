using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class SaveGame : Singleton<SaveGame>
{
    public static SaveGame gameSave;

    // Start is called before the first frame update
    void Awake()
    {
        if (gameSave == null)
        {
            DontDestroyOnLoad (gameObject);
            gameSave = this;
        }

        else if (gameSave != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Save()
    {
        SerializedData mySerializedData = new SerializedData();
        mySerializedData.ser_score = GameData.gameScore;
        mySerializedData.ser_health = GameData.PlayerHealth;
        mySerializedData.ser_ammoamount = GameData.AmmoAmount;
        mySerializedData.ser_scenename = EditorSceneManager.GetActiveScene().path;

        // Check if the scene has been saved before
        if (!string.IsNullOrEmpty(mySerializedData.ser_scenename))
        {
            // Save the scene
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
            Debug.Log("Scene saved: " + mySerializedData.ser_scenename);
        }
        else
        {
            Debug.LogError("Scene has not been saved yet. Please save the scene manually before using this function.");
        }

        BinaryFormatter bf = new BinaryFormatter();

        FileStream myfile = File.Create(Application.persistentDataPath + "/ApocalypseData.save");
        Debug.Log(Application.persistentDataPath.ToString());
        bf.Serialize(myfile, mySerializedData);  //Serialize and save
        myfile.Close();
        Debug.Log("FILE SAVED");
    }

    public void Load()
    {
        SerializedData mySerializedData = new SerializedData();

        if (File.Exists(Application.persistentDataPath + "/ApocalypseData.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream myfile = File.Open(Application.persistentDataPath + "/ApocalypseData.save", FileMode.Open);
            mySerializedData = (SerializedData)bf.Deserialize(myfile);
            myfile.Close();

            GameData.gameScore = mySerializedData.ser_score;
            GameData.PlayerHealth = mySerializedData.ser_health;
            GameData.AmmoAmount = mySerializedData.ser_ammoamount;
            GameData.SceneName = mySerializedData.ser_scenename;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(GameData.SceneName);
    }

    public void Delete()
    {
        if (File.Exists(Application.persistentDataPath + "/ApocalypseData.save"))
        {
            File.Delete(Application.persistentDataPath + "/ApocalypseData.save");
        }
    }
}