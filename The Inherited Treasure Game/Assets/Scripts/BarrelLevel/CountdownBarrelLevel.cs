using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(SaveSystem))]

public class CountdownBarrelLevel : MonoBehaviour
{
    public Text timeLeft;
    public float time = 10;
    public string nextLevel;
    string levelType;
    public NextLevelMenu menu;
    public LevelCompletedMenu menu2;
    public SaveSystem saveSystem;

    void Start()
    {
        Time.timeScale = 1;
        timeLeft.text = "Tempo Restante: " + time;
        saveSystem = GetComponent<SaveSystem>();
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timeLeft.text = "Tempo Restante: " + Mathf.Round(time).ToString();
        }
        else
        {

            levelType = saveSystem.getGameType();
            if(levelType == "FULL")
            {
                timeLeft.gameObject.SetActive(false);
                Time.timeScale = 0;
                menu.Setup();
            }
            else if (levelType == "SINGLE")
            {
                timeLeft.gameObject.SetActive(false);
                Time.timeScale = 0;
                menu2.Setup();
            }
            
        }

    }
}
