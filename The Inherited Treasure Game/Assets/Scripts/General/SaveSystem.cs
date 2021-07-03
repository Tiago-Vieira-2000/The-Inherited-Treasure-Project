using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{

    int sceneNumber;

    public void SaveData()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Data.dat");
        PlayerData data = new PlayerData();

        data.SceneNumber = sceneNumber;
        data.numberPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        data.score = 0;

        bf.Serialize(file, data);
        file.Close();
    }

    public void nextLevelData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Data.dat");
        PlayerData data = new PlayerData();

        data.numberPlayers = GameObject.FindGameObjectsWithTag("Player").Length;

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

    public int getSceneNumber()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Data.dat", FileMode.Open);
        PlayerData data = (PlayerData)bf.Deserialize(file);

        file.Close();

        return data.SceneNumber;
    }

    public int getDifficultyLevel()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
        GameData data = (GameData)bf.Deserialize(file);

        file.Close();

        return data.getDiff();
    }

    public void setGameData(int difficulty, string type)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/GameData.dat");
        GameData data = new GameData();

        data.difficulty = difficulty;
        data.typeGame = type;
        
        bf.Serialize(file, data);
        file.Close();

        
    }

    public string getGameType()
    {
        if (File.Exists(Application.persistentDataPath + "/GameData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);

            file.Close();

            return data.getType();
        }
        else
        {
            Debug.Log("File does not exist");
            return "";
        }
    }

 
    public void restartData()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Data.dat", FileMode.Open);
        PlayerData data = new PlayerData();

        data.SceneNumber = 0;
        data.numberPlayers = 4;
        data.score = 0;


        bf.Serialize(file, data);
        file.Close();
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
    public int score;
}

[Serializable]
class GameData
{
    public int difficulty;
    public string typeGame;

    public int getDiff()
    {
        return difficulty;
    }

    public string getType()
    {
        return typeGame;
    }
}
