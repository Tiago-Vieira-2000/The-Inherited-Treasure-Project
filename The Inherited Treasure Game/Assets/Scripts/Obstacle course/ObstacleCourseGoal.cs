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
            finishedPlayers++;
        }
    }

    public int HowManyFinishedPlayers()
    {
        return finishedPlayers;
    }
}
