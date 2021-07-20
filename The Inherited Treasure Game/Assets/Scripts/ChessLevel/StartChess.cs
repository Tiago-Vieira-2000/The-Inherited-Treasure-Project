using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChess : MonoBehaviour
{
    int diff;
    public SaveSystem startGame;
    int nPlayers;
    int characterAmount;

    // Start is called before the first frame update
    void Start()
    {
        characterAmount = startGame.getPlayers();
        diff = startGame.getDifficultyLevel();
        startGame = GetComponent<SaveSystem>();
        nPlayers = startGame.getPlayers();

        if (diff == 2)
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length > nPlayers)
            {
                for (int i = 4 - characterAmount; i > 0; i--)
                {
                    Destroy(GameObject.Find("Player" + i));
                }
            }
        }
        else if (diff == 3)
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length > nPlayers)
            {
                for (int i = 4 - characterAmount; i > 0; i--)
                {
                    Destroy(GameObject.Find("Player" + i));
                }
            }
        }
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
