using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeGame : MonoBehaviour
{
    public int characterAmount;
    private List<string> colours;
    private float time = 0;
    private bool finished = false;
    private int maxTime = 600;
    private int score = 0;
    int diff;
    int nPlayers;
    public SaveSystem startGame;
    public NextLevelMenu nextLevelMenu;
    public GameOver gameOverMenu;
    public LevelCompletedMenu gameOverSingle;
    public LevelCompletedMenu levelSingle;

    /// <summary>
    /// Method that starts the Game, destroys any unwanted object depending on characterAmount including characters
    /// colours         -> colours available in the game (boxes, buttons, doors)
    /// characterAmount -> amount of characters that are still alive
    /// </summary>
    void Start()
    {
        startGame = GetComponent<SaveSystem>();
        //startGame.restartData();
        characterAmount = startGame.getPlayers();
        //characterAmount = 1;
        //DestroyUnnecessaryObjects();
        //KillCharacters();
        colours = new List<string>();
        colours.Add("yellow");
        colours.Add("blue");
        colours.Add("green");
        colours.Add("purple");
        diff = startGame.getDifficultyLevel();
        nPlayers = startGame.getPlayers();
        if(diff == 2)
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length > nPlayers)
            {
                for (int i = 4 - characterAmount; i > 0; i--)
                {
                    Destroy(GameObject.Find("Player" + i));
                }
            }
        }
        else if(diff == 3)
        {
            if(GameObject.FindGameObjectsWithTag("Player").Length > nPlayers)
            {
                for (int i = 4 - characterAmount; i > 0; i--)
                {
                    Destroy(GameObject.Find("Player" + i));
                }
            }
        }
        Time.timeScale = 0;
    }

    /// <summary>
    /// Method responsable for all game logic
    /// </summary>
    void Update()
    {
        string levelType = startGame.getGameType();
        if (!finished)
        {
            checkAllDoors();
            updateTimer();
            if (GameObject.Find("Goal").GetComponent<MazeGoal>().HowManyFinishedPlayers()>=characterAmount
                || time > maxTime) {
                setFinished();
            }
        }
        else {
            //How many characters can pass to the next level
            int characterLimit = 4;            
            if (time > maxTime){
                characterLimit = 0;
            }else if (time > maxTime * 0.83){
                characterLimit = 1;
            }else if (time > maxTime * 0.66){
                characterLimit = 2;
            } else if (time > maxTime * 0.5){
                characterLimit = 3;
            }

            while (characterLimit < characterAmount)
            {
                characterAmount--;
                KillCharacters();
            }

            //decide the score
            //TODO: save do score
            double x = 25 / (4/(maxTime*0.30));
            score = (int)(characterAmount / time * x);

            if (characterLimit>0) {
                if(levelType == "SINGLE")
                {
                    levelSingle.Setup();
                }
                else if(levelType == "FULL")
                {
                    nextLevelMenu.Setup();
                }
                
            } else {
                if (levelType == "SINGLE")
                {
                    gameOverSingle.Setup();
                }
                else if (levelType == "FULL")
                {
                    gameOverMenu.Setup();
                }
                
            }
        }
    }

    /// <summary>
    /// Method responsable for updating the Timer.
    /// </summary>
    void updateTimer() {
        time += Time.deltaTime;
        int mins = 0;
        int secs = (int)time;

        while (secs>=60) {
            mins++;
            secs -= 60;
        }

        string minutes = mins.ToString();
        string seconds = secs.ToString();

        if (secs < 10) {
            seconds = "0"+secs.ToString();
        }
        if (mins < 10)
        {
            minutes = "0" + mins.ToString();
        }

        if (secs>0 || mins>0)
        {
            GameObject.Find("Time").GetComponent<Text>().text = minutes + ":" + seconds;
        }        
    }

    /// <summary>
    /// Method responsable for destroying any unwanted object depending on characterAmount
    /// </summary>
    void DestroyUnnecessaryObjects() {
        if (characterAmount != 1) {
            Destroy(GameObject.Find("1Player"));
        }
        if (characterAmount != 2) {
            Destroy(GameObject.Find("2Players"));
        }
        if (characterAmount < 3) {
            Destroy(GameObject.Find("AllPlayers"));
        }
    }

    /// <summary>
    /// Method responsable for destroying characters
    /// </summary>
    void KillCharacters()
    {
        for (int i = 4 - characterAmount; i > 0; i--)
        {
            Destroy(GameObject.Find("Player" + i));
        }
    }

    /// <summary>
    /// Method responsable for checking if any door needs to be updated
    /// </summary>
    void checkAllDoors()
    {
        foreach (string colour in colours) {
            checkDoor(colour);
        }
    }

    /// <summary>
    /// Method responsable for checking if the door needs to be updated
    /// Logic depends on characterAmount
    /// </summary>
    /// <param name="colour">colour of the door</param>
    void checkDoor(string colour) {
        if (characterAmount == 1)
        {
            bool state = checkButton("/1Player/Button1 ", colour + "/Cube (2)")
                && checkButton("/1Player/Button2 ", colour + "/Cube (2)");
            useDoor(colour, state);
        }
        else if (characterAmount == 1 || characterAmount == 2)
        {
            bool state = checkButton("/2Players/Button1 ", colour + "/Cube (2)")
                || checkButton("/2Players/Button2 ", colour + "/Cube (2)");
            useDoor(colour, state);
        }
        else
        {
            useDoor(colour, checkTwoButtonsActive(colour));
        }
    }

    /// <summary>
    /// Method responsable for checking if at least two buttons are beeing pressed
    /// </summary>
    /// <param name="colour">colour of the buttons</param>
    /// <returns>True if two or more buttons are beeing pressed</returns>
    bool checkTwoButtonsActive(string colour) {
        int counter = 0;
        for (int i = 1; i<=4; i++)
        {
            if (checkButton("/AllPlayers/Button"+i+" ", colour + "/Cube (2)")) {
                counter++;
            }
            if (counter >= 2) {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Method responsable for checking if the button is beeing pressed
    /// </summary>
    /// <param name="buttonName">name of the button</param>
    /// <param name="colour">colour of the button</param>
    /// <returns></returns>
    bool checkButton(string buttonName, string colour) {
        return GameObject.Find(buttonName + colour).GetComponent<Button>().isButtonActive();
    }

    /// <summary>
    /// Method responsable for changing the state of a door
    /// </summary>
    /// <param name="colour">Colour of the door</param>
    /// <param name="state">If door needs to be opened</param>
    void useDoor(string colour, bool state) {
        GameObject.Find("door "+colour).GetComponent<Door>().changeDoorState(state);
    }

    void setFinished() {
        finished = !finished;
    }

    public bool onePlayer()
    {
        if (characterAmount == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
