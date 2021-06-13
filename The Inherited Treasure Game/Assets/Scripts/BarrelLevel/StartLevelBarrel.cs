using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[RequireComponent(typeof(SaveSystem))]


public class StartLevelBarrel : MonoBehaviour
{
    public Rigidbody player1;
    public SaveSystem startGame;
    int nPlayers;

    // Start is called before the first frame update
    void Start()
    {
        startGame = GetComponent<SaveSystem>();
        nPlayers = startGame.getPlayers();
        for(int i = 0; i < nPlayers; i++)
        {
            if(i == 0)
            {
                float x = 7f;
                float y = -1f;
                float z = -4.75f;
                transform.position = new Vector3(x, y, z);
                Instantiate(player1, transform.position, transform.rotation);
            }
            else if(i == 1)
            {
                float x = 3f;
                float y = -1f;
                float z = -4.75f;
                transform.position = new Vector3(x, y, z);
                Instantiate(player1, transform.position, transform.rotation);
            }
            else if (i == 2)
            {
                float x = -1f;
                float y = -1f;
                float z = -4.75f;
                transform.position = new Vector3(x, y, z);
                Instantiate(player1, transform.position, transform.rotation);
            }
            else if (i == 3)
            {
                float x = -5f;
                float y = -1f;
                float z = -4.75f;
                transform.position = new Vector3(x, y, z);
                Instantiate(player1, transform.position, transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
