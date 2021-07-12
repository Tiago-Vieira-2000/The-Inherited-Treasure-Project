using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(SaveSystem))]

public class DifficultySelectMenu : MonoBehaviour
{
    public SaveSystem diff;

    /// <summary>
    /// Receives SaveSystem script
    /// </summary>
    public void Start()
    {
        diff = GetComponent<SaveSystem>();
    }

    /// <summary>
    /// Sets up difficulty level
    /// </summary>
    /// <param name="d"></param>
    public void setupDifficulty(int d)
    {
        diff.restartData();
        diff.setGameData(d, "FULL");
        SceneManager.LoadScene("BarrelLevel");
    }

    

}
