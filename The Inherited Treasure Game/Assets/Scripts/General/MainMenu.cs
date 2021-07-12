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
    public void Start()
    {
        load = GetComponent<SaveSystem>();
    }



    public void loadGame()
    {
        load.LoadData();
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
