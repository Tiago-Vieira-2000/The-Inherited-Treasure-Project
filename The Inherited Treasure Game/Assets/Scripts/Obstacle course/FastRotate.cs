using UnityEngine;

public class FastRotate : MonoBehaviour
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
            time = Random.Range(5f, 10f);
            stopped = false;
        }        
    }

    /// <summary>
    /// Rotates the platform 180º
    /// </summary>
    private void rotate()
    {
        float rotation = this.gameObject.transform.localRotation.eulerAngles.y;
        if (!stopped)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
            if (stop((int)rotation) && moved) {
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

    /// <summary>
    /// Stops the platform when it's on the right angle
    /// </summary>
    /// <param name="rotation">Current angle of the platform</param>
    /// <returns>If the platform is on the right angle</returns>
    bool stop(int rotation)
    {
        if (rotation == 1 ||
            rotation == 180)
        {
            
            return true;
        }
        return false;
    }

    /// <summary>
    /// Detects if the platform moved by checking if platform to a certain angle
    /// </summary>
    /// <param name="rotation">Current angle of the platform</param>
    /// <returns>If the platform moved</returns>
    bool platformMoved(int rotation)
    {
        if (rotation == 90 ||
            rotation == 270)
        {
            return true;
        }
        return false;
    }
}
