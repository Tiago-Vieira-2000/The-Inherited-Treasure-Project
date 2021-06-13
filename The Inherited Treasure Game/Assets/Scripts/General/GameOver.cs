using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SaveSystem loadSave;
    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        loadSave = GetComponent<SaveSystem>();
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
