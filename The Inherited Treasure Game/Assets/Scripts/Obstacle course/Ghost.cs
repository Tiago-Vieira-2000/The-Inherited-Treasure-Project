using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private float time;
    private Vector3 originalPosition;

    void Start()
    {
        time = Random.Range(5f, 7f);
        originalPosition = transform.position;
    }

    /// <summary>
    /// The Ghost Platform is a platform that disapears every few seconds
    /// </summary>
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = Random.Range(5f, 7f);
            changeLocation();
        }
    }

    /// <summary>
    /// Instead of actually making the platform disapear, it changes the location of the platform instantly having the same effect
    /// </summary>
    void changeLocation() {
        if (originalPosition == transform.position) {
            transform.position = new Vector3(100,100,100);
        }
        else {            
            transform.position = originalPosition;
        }
    }
}
