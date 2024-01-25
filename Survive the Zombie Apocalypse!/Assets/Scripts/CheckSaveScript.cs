using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class CheckSaveScript : MonoBehaviour
{
    [SerializeField] GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/ApocalypseData.save"))
        {
            Debug.Log(Application.persistentDataPath + "/ApocalypseData.save");
            continueButton.SetActive(true);
        }
    }
}
