using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(GameOver))]


public class deathZone : MonoBehaviour
{
    int count = 0;
    public GameOver gameOverMenu;

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
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            gameOverMenu.Setup();
            Debug.Log("All players dead");
        }

    }

}
