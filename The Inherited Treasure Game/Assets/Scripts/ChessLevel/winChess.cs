using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winChess : MonoBehaviour
{
    public GameObject Gem1;
    public GameObject Gem2;
    public GameObject Gem3;
    public GameObject Gem4;
    private int totalGems;

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
        if(totalGems == GameObject.FindGameObjectsWithTag("Player").Length){
            Debug.Log("Win :P");
            enabled = false;
        }
    }
}
