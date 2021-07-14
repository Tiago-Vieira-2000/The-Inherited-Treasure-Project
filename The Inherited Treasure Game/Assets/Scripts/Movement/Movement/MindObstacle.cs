using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindObstacle : MonoBehaviour
{
    public List<GameObject> Players;
    [SerializeField]

    GameObject currentPlayer;

    void Start()
    {
        for (int i = 1; i < Players.Count; i++)
        {
            Players[i].GetComponent<moveZAxis>().enabled = false;
        }

        currentPlayer = Players[0];
    }

    private void Update()
    {
        if (currentPlayer == null)
        {
            currentPlayer = Players[0];
        }

        for (int i = 1; i < Players.Count; i++)
        {
            if (Players[i] == null)
            {
                Players.Remove(Players[i]);
            }
        }
    }
    public void changePlayer(GameObject player)
    {
        currentPlayer.GetComponent<moveZAxis>().enabled = false;
        currentPlayer = player;
        currentPlayer.GetComponent<moveZAxis>().enabled = true;

        stopPlayers(currentPlayer);

    }
    public void removePlayer(GameObject player)
    {
        Players.Remove(player);
    }
    public void stopPlayers(GameObject player)
    {
        {
            for (int i = 1; i < Players.Count; i++)
            {
                if (!Players[i] == player)
                    Players[i].GetComponent<moveZAxis>().enabled = false;
            }


        }

    }
}
