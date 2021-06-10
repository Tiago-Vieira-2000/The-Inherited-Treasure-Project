using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(SaveSystem))]


public class NextLevelMenu : MonoBehaviour
{

    public SaveSystem save;

    public void Start()
    {
        save = GetComponent<SaveSystem>();    
    }

    public void Setup()
    {
        gameObject.SetActive(true);
     
    }

    public void NextLevel(string nextLevel)
    {
        SceneManager.LoadScene(nextLevel.ToString());
        
    }
        

    public void saveQuit()
    {
        //Time.timeScale = 1;
        save.SaveData(0);
        string quit = "MainMenu";
        SceneManager.LoadScene(quit);
    }
}
