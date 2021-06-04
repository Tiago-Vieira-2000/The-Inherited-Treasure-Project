using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int characterAmount;
    private List<string> colours;
    private float time = 0;
    private bool finished = false;

    void Start()
    {
        characterAmount = 1;
        DestroyUnnecessaryObjects();
        colours = new List<string>();
        colours.Add("yellow");
        colours.Add("blue");
        colours.Add("green");
        colours.Add("purple");
    }

    
    void Update()
    {
        if (!finished) {
            checkColour();
            updateTimer();
        }
    }

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

        GameObject.Find("Time").GetComponent<Text>().text = minutes + ":" + seconds;
    }

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

    void checkColour()
    {
        foreach (string colour in colours) {
            checkDoor(colour);
        }
    }

    void checkDoor(string colour) {
        if (characterAmount == 1)
        {
            useDoor(colour, checkButton("/1Player/Button1 ", colour+"/Cube (2)"));
        }
        else if (characterAmount == 2)
        {
            useDoor(colour, checkButton("/2Players/Button1 ", colour + "/Cube (2)"));
            useDoor(colour, checkButton("/2Players/Button2 ", colour + "/Cube (2)"));
        }
        else
        {
            useDoor(colour, checkTwoButtonsActive(colour));
        }
    }

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

    bool checkButton(string button, string colour) {
        return GameObject.Find(button + colour).GetComponent<Button>().isButtonActive();
    }

    void useDoor(string colour, bool state) {
        GameObject.Find("door "+colour).GetComponent<Door>().changeDoorState(state);
    }

    void setFinished() {
        finished = !finished;
    }
}
