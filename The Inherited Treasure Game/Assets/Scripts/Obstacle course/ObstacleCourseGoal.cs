using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCourseGoal : MonoBehaviour
{
    private int finishedPlayers;
    void Start()
    {
        finishedPlayers = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Platform").GetComponent<ObstacleCourseGame>().turnLightsColor(other.name, Color.green);
            finishedPlayers++;
        }
    }

    public int HowManyFinishedPlayers()
    {
        return finishedPlayers;
    }
}
