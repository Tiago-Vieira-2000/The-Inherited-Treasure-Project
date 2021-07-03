using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(SaveSystem))]


public class NextLevelMenu : MonoBehaviour
{

    public SaveSystem save;
    public GameObject buttonSaveQuit;
    public GameObject buttonQuit;

    public void Start()
    {
        save = GetComponent<SaveSystem>();    
    }

    public void Setup()
    {
        int diff = save.getDifficultyLevel();
        int sceneNum = save.getSceneNumber();

        if (diff == 1)
        {
            gameObject.SetActive(true);
        }
        else if(diff == 2)
        {
            gameObject.SetActive(true);
            if (sceneNum != 2)
            {
                buttonSaveQuit.SetActive(false);
                buttonQuit.SetActive(true);
            }
            
        }
        else if(diff == 3)
        {
            gameObject.SetActive(true);
            buttonSaveQuit.SetActive(false);
            buttonQuit.SetActive(true);
        }
        
    }

    public void NextLevel(string nextLevel)
    {
        save.nextLevelData();
        SceneManager.LoadScene(nextLevel.ToString());
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void saveQuit()
    {
        int diff = save.getDifficultyLevel();
        int sceneNum = save.getSceneNumber();
        string quit = "MainMenu";
        if (diff == 1)
        {
            save.SaveData();
            SceneManager.LoadScene(quit);
        }
        else if(diff == 2)
        {
            if(sceneNum == 2)
            {
                save.SaveData();
                SceneManager.LoadScene(quit);
            }
            else
            {
                SceneManager.LoadScene(quit);
                Debug.LogError("Can't save data in this level");
            }
        }
        else if(diff == 3)
        {
            SceneManager.LoadScene(quit);
            Debug.LogError("Can't save data on this difficulty");
        }
    }
}
