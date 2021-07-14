using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    /// <summary>
    /// Receives Rigidbody object
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Adds movement to object with this script
    /// </summary>
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0, 0.0f, 0);
        if (Input.GetMouseButton(0))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, speed));

            rb.AddForce(movement * speed);
        }
    }
}
