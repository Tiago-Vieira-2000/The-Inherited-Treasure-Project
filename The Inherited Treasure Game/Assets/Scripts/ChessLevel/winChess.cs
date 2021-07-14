using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winChess : MonoBehaviour
{
    public GameObject Gem1;
    public GameObject Gem2;
    public GameObject Gem3;
    public GameObject Gem4;
    public NextLevelMenu menu1;
    public LevelCompletedMenu menu2;
    private int totalGems;
    private string levelType;
    public SaveSystem saveSystem;
    void Start()
    {
        saveSystem = GetComponent<SaveSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        totalGems=0;
        if(Gem1.activeSelf){
            totalGems++;
        }
        if(Gem2.activeSelf){
            totalGems++;
        }
        if(Gem3.activeSelf){
            totalGems++;
        }
        if(Gem4.activeSelf){
            totalGems++;
        }
        if(totalGems == GameObject.FindGameObjectsWithTag("Player").Length && totalGems != 0){

            levelType = saveSystem.getGameType();
            if (levelType == "FULL")
            {
                Time.timeScale = 0;
                menu1.Setup();
            }
            else if (levelType == "SINGLE")
            {
                Time.timeScale = 0;
                menu2.Setup();
            }
        }
    }
}
