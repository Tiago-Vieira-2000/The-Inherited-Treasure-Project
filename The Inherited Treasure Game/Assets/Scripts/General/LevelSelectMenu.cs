using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(SaveSystem))]


public class LevelSelectMenu : MonoBehaviour
{
    public SaveSystem gameType;

    /// <summary>
    /// Receives Save System Script
    /// </summary>
    private void Start()
    {
        gameType = GetComponent<SaveSystem>();
    }

    /// <summary>
    /// Loads selected Level
    /// </summary>
    /// <param name="level"></param>
    public void levelSelect(string level)
    {
        SceneManager.LoadScene(level);
        gameType.restartData();
        gameType.setGameData(1, "SINGLE");
    }
}
