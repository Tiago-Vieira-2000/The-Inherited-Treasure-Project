using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool hasGem;
    // Start is called before the first frame update
    void Start()
    {
        hasGem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasGem){
            Debug.Log("Jogador tem a gema");
            enabled = false;
        }
    }
}
