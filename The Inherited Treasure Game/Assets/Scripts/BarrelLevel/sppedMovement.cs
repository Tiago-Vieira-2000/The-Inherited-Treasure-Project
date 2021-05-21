using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sppedMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        transform.position += Vector3.back * speed * Time.deltaTime;

        rb.AddForce(movement * speed);
    }
}
