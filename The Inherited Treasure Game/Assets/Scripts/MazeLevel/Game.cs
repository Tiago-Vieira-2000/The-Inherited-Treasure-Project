using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public int characterAmount;
    public int time;
    void Start()
    {
        DestroyUnnecessaryObjects();
    }

    
    void Update()
    {
        if (time == 250)
        {
            GameObject.Find("door yellow").GetComponent<Door>().changeDoorState();
        }
        if (time == 500)
        {
            GameObject.Find("door blue").GetComponent<Door>().changeDoorState();
        }
        if (time == 750)
        {
            GameObject.Find("door purple").GetComponent<Door>().changeDoorState();
        }
        if (time == 1000)
        {
            GameObject.Find("door green").GetComponent<Door>().changeDoorState();
        }
        if (time == 2000)
        {
            GameObject.Find("door yellow").GetComponent<Door>().changeDoorState();
            GameObject.Find("door blue").GetComponent<Door>().changeDoorState();
            GameObject.Find("door purple").GetComponent<Door>().changeDoorState();
            GameObject.Find("door green").GetComponent<Door>().changeDoorState();
        }
        time++;
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
}
