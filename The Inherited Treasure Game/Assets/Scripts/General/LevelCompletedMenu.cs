using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletedMenu : MonoBehaviour
{
    /// <summary>
    /// Sets game object as active
    /// </summary>
    public void Setup()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Restarts level
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Goes to Main Menu Scene
    /// </summary>
    public void Leave()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
