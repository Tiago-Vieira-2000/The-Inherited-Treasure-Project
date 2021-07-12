using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SaveSystem loadSave;
    public GameObject saveButton;

    /// <summary>
    /// Sets up game over menu
    /// </summary>
    public void Setup()
    {
        int diff = loadSave.getDifficultyLevel();
        loadSave = GetComponent<SaveSystem>();
        gameObject.SetActive(true);
        Time.timeScale = 0;
        if(diff == 3)
        {
            saveButton.SetActive(false);
        }
        
        
    }

    /// <summary>
    /// Goes to Main Menu scene
    /// </summary>
    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Loads last save
    /// </summary>
    public void loadLastSave()
    {
        Time.timeScale = 1;
        loadSave.LoadData();
    }
}
