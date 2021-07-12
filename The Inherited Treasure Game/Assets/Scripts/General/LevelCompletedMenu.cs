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
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Restarts level
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Goes to Main Menu Scene
    /// </summary>
    public void Leave()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
