using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class deathZone : MonoBehaviour
{
    int count = 0;
    public GameOver gameOverMenu;
    public LevelCompletedMenu gameOverSingle;
    public SaveSystem saveSystem;

    private void Start()
    {
        saveSystem = GetComponent<SaveSystem>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            count++;
            Destroy(other.gameObject);
            Debug.Log("Player killed " + count);
        }
        else
        {
            Destroy(other.gameObject);
            Debug.Log("Object destroyed");
        }

    }

  

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
