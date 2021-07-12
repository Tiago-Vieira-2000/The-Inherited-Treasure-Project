using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCourseGame : MonoBehaviour
{
    public int characterAmount;
    private int score = 0;
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
        KillCharacters();
    }

    /// <summary>
    /// All Game logic
    /// </summary>
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
            score = characterAmount*(4/25);
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

    /// <summary>
    /// Destroy characters depending on the saved characterAmount and updates the lights
    /// </summary>
    void KillCharacters()
    {
        for (int i = 4 - characterAmount; i > 0; i--)
        {
            turnLightsRed("Player" + i);
            Destroy(GameObject.Find("Player" + i));
        }
    }

    /// <summary>
    /// Updates lights and characterAmount
    /// </summary>
    /// <param name="name">Name of the character that died</param>
    public void characterDied(string name) {
        turnLightsRed(name);
        characterAmount--;
    }

    /// <summary>
    /// Turn a Light row red
    /// </summary>
    /// <param name="name">Name of the character that died</param>
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
