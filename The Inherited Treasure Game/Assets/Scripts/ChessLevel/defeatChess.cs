using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defeatChess : MonoBehaviour
{
    public GameOver gameOverMenu;
    public LevelCompletedMenu gameOverSingle;
    public SaveSystem saveSystem;

    private void Start()
    {
        saveSystem = GetComponent<SaveSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 0){
            GameObject.Find("mind").GetComponent<MindChess>().enabled = false;
            string typeGame = saveSystem.getGameType();
            if (typeGame == "FULL")
            {
                gameOverMenu.Setup();
            }
            else if (typeGame == "SINGLE")
            {
                gameOverSingle.Setup();
            }
        }
    }
}
