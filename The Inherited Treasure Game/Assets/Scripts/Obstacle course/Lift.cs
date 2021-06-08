using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    private float speed;
    private float time;
    private Vector3 originalPosition;

    void Start()
    {
        speed = Random.Range(1f, 3f);
        time = Random.Range(5f, 7f);
        originalPosition = transform.position;
    }

    void Update()
    {
        Vector3 a = originalPosition;
        a.y += 1.5f * Mathf.Sin(Time.time * speed);
        transform.position = a;
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = Random.Range(5f, 7f);
            speed = Random.Range(1f, 3f);
        }
    }
}
