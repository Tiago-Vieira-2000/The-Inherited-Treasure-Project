using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(SaveSystem))]


public class LevelSelectMenu : MonoBehaviour
{
    public SaveSystem gameType;

    private void Start()
    {
        gameType = GetComponent<SaveSystem>();
    }
    public void levelSelect(string level)
    {
        SceneManager.LoadScene(level);
        gameType.restartData();
        gameType.setGameData(1, "SINGLE");
    }
}
