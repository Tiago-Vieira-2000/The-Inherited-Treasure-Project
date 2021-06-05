using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelMenu : MonoBehaviour
{

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void NextLevel(string nextLevel)
    {
        SceneManager.LoadScene(nextLevel.ToString());
    }
}
