using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
        //Time.timeScale = 0;
    }

    public void QuitGame()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
