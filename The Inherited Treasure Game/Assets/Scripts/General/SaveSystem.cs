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

    /// <summary>
    /// Save Game Data
    /// </summary>
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

    public double GetScore()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Data.dat", FileMode.Open);
        PlayerData data = (PlayerData)bf.Deserialize(file);

        file.Close();

        return data.score;
    }

    /// <summary>
    /// Saves data to next Level
    /// </summary>
    /// <param name="score"></param>
    public void nextLevelData(double score)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Data.dat");
        PlayerData data = new PlayerData();

        data.numberPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        data.score += score;

        bf.Serialize(file, data);
        file.Close();
    }

    /// <summary>
    /// Returns Number of players
    /// </summary>
    /// <returns></returns>
    public int getPlayers()
    {
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Data.dat", FileMode.Open);
        PlayerData data = (PlayerData)bf.Deserialize(file);

        file.Close();
        
        return data.numberPlayers;
    }

    /// <summary>
    /// Return number of Scene
    /// </summary>
    /// <returns></returns>
    public int getSceneNumber()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Data.dat", FileMode.Open);
        PlayerData data = (PlayerData)bf.Deserialize(file);

        file.Close();

        return data.SceneNumber;
    }

    /// <summary>
    /// Return difficulty level
    /// </summary>
    /// <returns></returns>
    public int getDifficultyLevel()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
        GameData data = (GameData)bf.Deserialize(file);

        file.Close();

        return data.getDiff();
    }

    /// <summary>
    /// Sets up difficulty and type of game
    /// </summary>
    /// <param name="difficulty"></param>
    /// <param name="type"></param>
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

    /// <summary>
    /// Return game type
    /// </summary>
    /// <returns></returns>
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
            //Debug.Log("File does not exist");
            return "";
        }
    }

    /// <summary>
    /// Restarts game data
    /// </summary>    
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

    /// <summary>
    /// Loads saved game data
    /// </summary>
    public void LoadData()
    {
        Debug.Log("Here");
        if (File.Exists(Application.persistentDataPath + "/Data.dat"))
        {
           
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Data.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);

            file.Close();

            PlayerPrefs.DeleteAll();

            int newScene = data.SceneNumber + 1;
            Debug.Log(data.SceneNumber);
            SceneManager.LoadScene(newScene);
             }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}


[Serializable]
class PlayerData
{
    public int SceneNumber;
    public int numberPlayers;
    public double score;
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
