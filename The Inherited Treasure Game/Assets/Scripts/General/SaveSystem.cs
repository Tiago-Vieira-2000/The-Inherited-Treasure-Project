using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{

    GameObject[] players;
    int sceneNumber;
    public GameObject prefab;


    public void SaveData(int score)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        sceneNumber = SceneManager.GetActiveScene().buildIndex;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Data.dat");
        PlayerData data = new PlayerData();
        int countPlayers = 0;

        data.SceneNumber = sceneNumber;
        data.numberPlayers = players.Length;
        data.posx = players[countPlayers].transform.position.x;
        
        data.posy = players[countPlayers].transform.position.y;
        data.posz = players[countPlayers].transform.position.z;
        
        Debug.Log("X : " +data.posx);
        Debug.Log("Y " + data.posy);
        Debug.Log("Z: " + data.posz);
        data.score = score;

        bf.Serialize(file, data);
        file.Close();
    }

    public int getPlayers()
    {
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Data.dat", FileMode.Open);
        PlayerData data = (PlayerData)bf.Deserialize(file);

        file.Close();
        
        return data.numberPlayers;
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/Data.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Data.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);

            file.Close();

            PlayerPrefs.DeleteAll();

            int newScene = data.SceneNumber + 1;
            SceneManager.LoadScene(newScene);
     
            
            Debug.Log("Number of players " + data.numberPlayers);
        }
        else
        {
            Debug.Log("File does not exist");
        }
    }
}


[Serializable]
class PlayerData
{
    public int SceneNumber;
    public int numberPlayers;

    public float posx;
    public float posy;
    public float posz;

    public int score;
}
