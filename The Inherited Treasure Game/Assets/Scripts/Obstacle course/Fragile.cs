using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragile : MonoBehaviour
{
    private float speed;
    private float time;
    private bool beeingTouched;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private int direction;

    void Start()
    {
        speed = 9.5f;
        time = 0;
        beeingTouched = false;
        direction = 1;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    /// <summary>
    /// The Fragile Platform fall if a character stand in it for to long
    /// </summary>
    void Update()
    {
        if (beeingTouched && time < 5){
            time += Time.deltaTime;
        }
        else if (!beeingTouched && time > 0 && (transform.position.y < -6 || transform.position.y == 0))
        {
            time -= Time.deltaTime;
        }


        if (time <= 3 && time > 0)
        {
            shake();
        }
        else {
            transform.rotation = originalRotation;
        }

        if (time > 3)
        {
            fall();
        }
        else if (time <= 0)
        {
            goUp();
        }
    }

    /// <summary>
    /// Shaking animation
    /// </summary>
    private void shake()
    {
        float rotation = this.gameObject.transform.localRotation.eulerAngles.y;
        if (rotation < 357 && rotation >180) {
            direction = 1;
        }
        else if (rotation > 3 && rotation < 180)
        {
            direction = -1;
        }
        transform.Rotate(0, direction * 50 * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        beeingTouched = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        beeingTouched = false;
    }

    /// <summary>
    /// Moves the platform up to the original location
    /// </summary>
    private void goUp()
    {
        if (transform.position.y < originalPosition.y)
        {
            transform.Translate(0, speed * Time.deltaTime, 0, Space.Self);
        }
    }

    /// <summary>
    /// Moves the platform down
    /// </summary>
    private void fall()
    {
        if (transform.position.y > -6)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0, Space.Self);
        }
    }
}
