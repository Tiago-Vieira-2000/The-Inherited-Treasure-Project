using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[RequireComponent(typeof(SaveSystem))]


public class StartLevelBarrel : MonoBehaviour
{
    public SaveSystem startGame;
    int nPlayers;
    int diff;
    int characterAmount;

    // Start is called before the first frame update
    void Start()
    {
        startGame = GetComponent<SaveSystem>();
        characterAmount = startGame.getPlayers();
        nPlayers = startGame.getPlayers();
        diff = startGame.getDifficultyLevel();
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

 }
