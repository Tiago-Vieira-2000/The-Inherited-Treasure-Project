using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);

        rb.AddForce(movement * speed);

       
            if (Input.GetKey(KeyCode.Space))
            {
                if (this.gameObject.transform.position.y < 0.160000)
                {
                rb.AddForce(new Vector3(0, 0.4f, 0), ForceMode.Impulse);
                }
            }
        

    }
}

