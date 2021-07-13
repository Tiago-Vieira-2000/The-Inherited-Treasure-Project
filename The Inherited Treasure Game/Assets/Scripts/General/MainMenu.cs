using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[RequireComponent(typeof(SaveSystem))]


public class MainMenu : MonoBehaviour
{
    public SaveSystem load;
    /// <summary>
    /// Receives Save System Script
    /// </summary>
    public void Start()
    {
        load = GetComponent<SaveSystem>();
    }


    /// <summary>
    /// Loads saved game
    /// </summary>
    public void loadGame()
    {
        load.LoadData();
    }

    /// <summary>
    /// Leaves Game
    /// </summary>
    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
