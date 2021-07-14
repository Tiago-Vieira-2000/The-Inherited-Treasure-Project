using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindChess : MonoBehaviour
{
    public List<GameObject> Players;
    [SerializeField]

    GameObject currentPlayer;

    void Start()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].GetComponent<moveGrid>().enabled = false;
        }

        currentPlayer = Players[0];
    }

    private void Update()
    {
        if (currentPlayer == null)
        {
            currentPlayer = Players[0];
        }

        for (int i = 0; i < Players.Count; i++)
        {
            if (Players[i] == null)
            {
                Players.Remove(Players[i]);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>
    public void changePlayer(GameObject player)
    {
        if (currentPlayer == null)
        { 
            
        }
        currentPlayer.GetComponent<moveGrid>().enabled = false;
        currentPlayer = player;
        currentPlayer.GetComponent<moveGrid>().enabled = true;

        stopPlayers(currentPlayer);

    }
    public void removePlayer(GameObject player)
    {
        Players.Remove(player);
    }
    public void stopPlayers(GameObject player)
    {
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (!Players[i] == player)
                    Players[i].GetComponent<moveGrid>().enabled = false;
            }


        }

    }
}
