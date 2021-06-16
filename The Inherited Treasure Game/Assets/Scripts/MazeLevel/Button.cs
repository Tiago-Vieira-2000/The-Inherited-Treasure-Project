using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool isActive;
    private float MovementSpeed;
    private float position;
    private bool moving;

    /// <summary>
    /// Method that starts the Button unpressed and still.
    /// </summary>
    void Start()
    {
        position = transform.position.y;
        isActive = false;
        moving = false;
        MovementSpeed = 1.0f;
    }

    /// <summary>
    /// Method responsable for contantly checking if the Button needs to be updated.
    /// </summary>
    void Update()
    {
        if (moving) {
            if (!isActive) {
                press(); 
            }
            else {
                unpress(); 
            }
        }
    }

    /// <summary>
    /// Method responsable for pressing the Button when it's beeing touched.
    /// </summary>
    /// <param name="other">Object that touches the Button</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box") || other.CompareTag("Player"))
        {
            if (!isActive)
            {
                moving = true;
            }
        }
    }

    /// <summary>
    /// Method responsable for unpressing the Button when it stopeed beeing touched.
    /// </summary>
    /// <param name="other">Object that stoped touching the Button</param>
    private void OnTriggerExit(Collider other)
    {
        if (isActive)
        {
            moving = true;
        }
    }

    /// <summary>
    /// Checks the Button's state
    /// </summary>
    /// <returns>If the button is currently beeing pressed</returns>
    public bool isButtonActive() {
        return isActive;
    }

    /// <summary>
    /// Method responsable for pressing the Button
    /// </summary>
    void press()
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

    /// <summary>
    /// Method responsable for unpressing the Button
    /// </summary>
    void unpress()
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

    /// <summary>
    /// Method responsable for fixing the Button's location in case of moving out of range
    /// </summary>
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
