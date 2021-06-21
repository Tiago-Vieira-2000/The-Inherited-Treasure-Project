using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRotate : MonoBehaviour
{
    private float speed;
    private float time;
    private bool stopped;
    private bool moved;

    void Start()
    {
        speed = 50f;
        time = 0;
        stopped = true;
        moved = false;
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            rotate();
        }
        else
        {
            time = Random.Range(0f, 5f);
            stopped = false;
        }
    }

    private void rotate()
    {
        float rotation = this.gameObject.transform.localRotation.eulerAngles.y;
        if (!stopped)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
            if ( stop((int)rotation) && moved)
            {
                stopped = true;
                moved = false;
                transform.rotation = Quaternion.Euler(0, (int)rotation, 0);
            }
            if (platformMoved((int)rotation))
            {
                moved = true;
            }
        }
    }

    bool stop(int rotation) {
        if (rotation == 1 ||
            rotation == 45 ||
            rotation == 90 ||
            rotation == 135 ||
            rotation == 180 ||
            rotation == 225 ||
            rotation == 270 ||
            rotation == 315)
        {
            return true;
        }
        return false;
    }

    bool platformMoved(int rotation)
    {
        if (rotation == 22 ||
            rotation == 66 ||
            rotation == 115 ||
            rotation == 150 ||
            rotation == 200 ||
            rotation == 250 ||
            rotation == 290 ||
            rotation == 350)
        {
            return true;
        }
        return false;
    }
}
