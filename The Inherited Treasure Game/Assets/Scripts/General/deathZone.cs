using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class deathZone : MonoBehaviour
{

    public GameOver gameOverMenu;
    public LevelCompletedMenu gameOverSingle;
    public SaveSystem saveSystem;

    /// <summary>
    /// Receives SaveSystem script
    /// </summary>
    private void Start()
    {
        saveSystem = GetComponent<SaveSystem>();    
    }

    /// <summary>
    /// On entering Trigger, if gameobject tag is "Player", will turn pathway lights red, else will just destroy it
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject.Find("Players").GetComponent<TurnLightsRedBarrellevel>().characterDied(other.gameObject.name);
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }

    }

    /// <summary>
    /// If object with tag Player don't exist, stops game and shows Game Over Menu
    /// </summary>
    private void Update()
    {
        string typeGame = saveSystem.getGameType();
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            if (typeGame == "FULL")
            {
                gameOverMenu.Setup();
            }
            else if(typeGame == "SINGLE")
            {
                gameOverSingle.Setup();
            }
        }
    }

}
