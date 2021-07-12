using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    private float speed;
    private Vector3 originalPosition;

    void Start()
    {
        speed = Random.Range(1f, 3f);
        originalPosition = transform.position;
    }

    void Update()
    {
        Vector3 a = originalPosition;
        a.y += 1.5f * Mathf.Sin(Time.time * speed);
        transform.position = a;
    }
}
