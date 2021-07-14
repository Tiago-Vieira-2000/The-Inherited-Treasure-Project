using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool hasGem;
    public GameObject Gem;
    public Rigidbody rb;
    // Start is called before the first frame update
    /// <summary>
    /// Initialize the variables
    /// </summary>
    void Start()
    {
        Gem.SetActive(false);
        hasGem = false;
    }

    // Update is called once per frame
    /// <summary>
    /// Informs the player that the character took the gem
    /// </summary>
    void Update()
    {
        if(hasGem){
            Debug.Log("Jogador tem a gema");
            enabled = false;
        }
    }
}
