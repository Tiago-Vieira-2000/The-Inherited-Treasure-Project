using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveZAxis : MonoBehaviour
{

    float speed = 6f;
    public Rigidbody player;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
            transform.position += Vector3.forward * speed * Time.deltaTime;
            player.AddForce(movement * speed);
        }
    }
}
