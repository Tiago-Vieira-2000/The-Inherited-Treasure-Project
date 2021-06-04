using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool isActive = false;
    private float MovementSpeed = 1.0f;
    private float position;
    private bool moving = false;

    void Start()
    {
        position = transform.position.y;
    }

    
    void Update()
    {
        if (moving) {
            if (!isActive) {
                pressAnimation(); 
            }
            else {
                unpressAnimation(); 
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box") || other.CompareTag("Character"))
        {
            if (!isActive)
            {
                moving = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isActive)
        {
            moving = true;
        }
    }

    public bool isButtonActive() {
        return isActive;
    }

    void pressAnimation()
    {
        if (position >= 2.021548)
        {
            position = transform.position.y;
            transform.Translate(0, -MovementSpeed * Time.deltaTime, 0, Space.Self);
        }
        else {
            isActive = true;
            moving = false;
            fixPosition();
        }
    }

    void unpressAnimation()
    {
        if (position <= 2.16526){
            position = transform.position.y;
            transform.Translate(0, MovementSpeed * Time.deltaTime, 0, Space.Self);
        }
        else{
            isActive = false;
            moving = false;
            fixPosition();
        }
    }

    void fixPosition() {
        position = transform.position.y;
        if (position < 2.021548){
            transform.position = new Vector3(transform.position.x, 2.021548f, transform.position.z);
        }
        if (position > 2.16526) {
            transform.position = new Vector3(transform.position.x, 2.16526f, transform.position.z);
        }
    }
}
