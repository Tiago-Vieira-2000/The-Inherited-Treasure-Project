using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SaveSystem loadSave;
    public GameObject saveButton;
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

    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }


    public void loadLastSave()
    {
        Time.timeScale = 1;
        loadSave.LoadData();
    }
}
