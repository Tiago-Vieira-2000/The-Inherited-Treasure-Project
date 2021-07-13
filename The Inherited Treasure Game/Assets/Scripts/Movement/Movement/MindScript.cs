using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindScript : MonoBehaviour
{
    public GameObject[] Players;
    [SerializeField]

    GameObject currentPlayer;

    void Start()
    {
        for (int i = 1 ; i < Players.Length; i++)
        {
            Players[i].GetComponent<NewBehaviourScript>().enabled = false;
        }

        currentPlayer = Players[0];
    }

    public void changePlayer(GameObject player){
        currentPlayer.GetComponent<NewBehaviourScript>().enabled = false;
        currentPlayer = player;
        currentPlayer.GetComponent<NewBehaviourScript>().enabled = true;
        
        stopPlayers(currentPlayer);
    
    }

    public void stopPlayers(GameObject player)
    {
        {
            for (int i = 1; i < Players.Length; i++)
            {
                if (!Players[i] == player)
                    Players[i].GetComponent<NewBehaviourScript>().enabled = false;
            }

            
        }

    }
}
