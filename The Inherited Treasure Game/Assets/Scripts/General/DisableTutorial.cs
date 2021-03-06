using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableTutorial : MonoBehaviour
{
    private float time = 0;
    private RawImage rawImage;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
        Time.timeScale = 0;
    }

    /// <summary>
    /// Method that stops all GameObjects that rely on time to move to show the tutorial picture
    /// <summary>
    void Update()
    {
        time += Time.unscaledDeltaTime;        
        int secs = (int)time;
        if (secs >= 10)
        {
            rawImage.enabled = false;
            Time.timeScale = 1;
        }
    }
}
