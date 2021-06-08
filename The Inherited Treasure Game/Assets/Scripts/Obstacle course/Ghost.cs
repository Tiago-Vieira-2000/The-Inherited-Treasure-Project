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

    // Update is called once per frame
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

    void changeLocation() {
        if (originalPosition == transform.position) {
            transform.position = new Vector3(100,100,100);
        }
        else {            
            transform.position = originalPosition;
        }
    }
}
