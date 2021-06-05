using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownBarrelLevel : MonoBehaviour
{
    public Text timeLeft;
    public float time = 10;
    public string nextLevel;
    public NextLevelMenu menu;

    void Start()
    {
        timeLeft.text = "Tempo Restante: " + time;
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timeLeft.text = "Tempo Restante: " + Mathf.Round(time).ToString();
        }
        else
        {
            timeLeft.gameObject.SetActive(false);
            menu.Setup();
            Debug.Log("Game Over");
        }

    }
}
