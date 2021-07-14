using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    public SaveSystem save;
    public Text scoreText;
    double score;
    
    public void Setup()
    {
        gameObject.SetActive(true);
        save = GetComponent<SaveSystem>();
        score = save.GetScore();
        score += GameObject.FindGameObjectsWithTag("Player").Length * 6.25;
        scoreText.text = "Score: " + score;
    }

    public void Leave()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}
