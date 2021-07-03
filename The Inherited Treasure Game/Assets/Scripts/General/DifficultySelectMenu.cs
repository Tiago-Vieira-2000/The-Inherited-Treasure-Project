using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(SaveSystem))]

public class DifficultySelectMenu : MonoBehaviour
{
    public SaveSystem diff;

    public void Start()
    {
        diff = GetComponent<SaveSystem>();
    }

    public void setupDifficulty(int d)
    {
        diff.restartData();
        diff.setGameData(d, "FULL");
        SceneManager.LoadScene("BarrelLevel");
    }

    

}
