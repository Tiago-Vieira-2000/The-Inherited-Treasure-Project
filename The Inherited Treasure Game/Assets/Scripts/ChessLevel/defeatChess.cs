using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defeatChess : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 0){
            Debug.Log("All characters have died, rip :)");
            GameObject.Find("mind").GetComponent<MindChess>().enabled = false;
            //Time.timeScale = 0;
            enabled = false;
        }
    }
}
