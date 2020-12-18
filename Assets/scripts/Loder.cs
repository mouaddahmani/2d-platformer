using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Loder : MonoBehaviour
{
    

    public PlayerData data()
    {
        string path = Application.persistentDataPath + "/Player.data";
        if (File.Exists(path))
        {
            PlayerData data = Savingsystem.LoadPlayer();
            return data;
        }
        return null;
    }

   
}
