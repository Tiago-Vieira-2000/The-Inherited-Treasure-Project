using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFlap : MonoBehaviour
{
    private float RotationSpeed = 50.0f;
    private float MovementSpeed = 0.5f;
    private bool opened;
    private float rotation;
    private bool desiredState;
    private bool moving;

    void Start()
    {
        if (gameObject.name.Contains("2"))
        {
            RotationSpeed = -50.0f;
        }
        opened = false;
        moving = false;
    }

    
    void Update()
    {
        changeDoorStateAnimation();
    }

    private void changeDoorStateAnimation() {
        if (desiredState && !opened)
        {
            openAnimation();
        }
        else if (moving || (!desiredState && opened))
        {
            closeAnimation();
        }
    }

    private void openAnimation()
    {
        moving = true;
        rotation = this.gameObject.transform.localRotation.eulerAngles.y;
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
        transform.Translate(-MovementSpeed * Time.deltaTime, 0, 0, Space.Self);
        if (RotationSpeed>0) {
            if (rotation >= 74) { setOpened(true); }
        }
        else {
            if (rotation <= 286 && rotation != 0) { setOpened(true); }
        }
    }

    private void closeAnimation()
    {
        moving = true;
        rotation = this.gameObject.transform.localRotation.eulerAngles.y;
        transform.Rotate(0, -RotationSpeed * Time.deltaTime, 0);
        transform.Translate(MovementSpeed * Time.deltaTime, 0, 0, Space.Self);
        if (RotationSpeed > 0)
        {
            if (rotation <= 1) { setOpened(false); }
        }
        else
        {
            if (rotation >= 359) { setOpened(false); }
        }
    }

    private void setOpened(bool state) {
        opened = state;
        moving = false;
    }

    public void changeDoorState(bool state) {
        desiredState = state;
    }
}
