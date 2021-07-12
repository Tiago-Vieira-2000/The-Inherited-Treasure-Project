using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCourseGame : MonoBehaviour
{
    public int characterAmount;
    public SaveSystem startGame;
    public NextLevelMenu nextLevelMenu;
    public LevelCompletedMenu levelSingle;
    public LevelCompletedMenu gameOverSingle;
    public GameOver gameOverMenu;

    void Start()
    {
        startGame = GetComponent<SaveSystem>();
        //startGame.restartData();
        characterAmount = startGame.getPlayers();
        //characterAmount = 1;
        DestroyUnnecessaryObjects();
    }

    // Update is called once per frame
    void Update()
    {
        string levelType = startGame.getGameType();
        if (characterAmount<=0)
        {
            if(levelType == "FULL")
            {
                gameOverMenu.Setup();
            }
            else if(levelType == "SINGLE")
            {
                gameOverSingle.Setup();
            }

        }
        else if (GameObject.Find("Goal").GetComponent<ObstacleCourseGoal>().HowManyFinishedPlayers() >= characterAmount)
        {
            if(levelType == "FULL")
            {
                nextLevelMenu.Setup();
            }
            else if(levelType == "SINGLE")
            { 

                levelSingle.Setup();
            }
            
        }
    }

    void DestroyUnnecessaryObjects()
    {
        for (int i = 4 - characterAmount; i > 0; i--)
        {
            turnLightsRed("Player" + i);
            Destroy(GameObject.Find("Player" + i));
        }
    }

    public void characterDied(string name) {
        turnLightsRed(name);
        characterAmount--;
    }

    void turnLightsRed(string name) {
        Light[] lights;
        lights = FindObjectsOfType(typeof(Light)) as Light[];
        foreach (Light light in lights)
        {
            if (light.name.Contains(name.Remove(0, 6)))
            {
                light.color = Color.red;
            }
        }        
    }
}
