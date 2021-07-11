using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    private float speed;
    private Vector3 originalPosition;

    void Start()
    {
        speed = Random.Range(1f, 3f);
        originalPosition = transform.position;
    }

    /// <summary>
    /// Swings the Cylinder from left to right
    /// </summary>
    void Update()
    {
        Vector3 a = originalPosition;
        a.x += -1.8f * Mathf.Sin(Time.time * speed);
        float delta = -0.5f;
        if (a.x < originalPosition.x)
        {
            delta = 0.5f;
        }
        a.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = a;
    }
}
