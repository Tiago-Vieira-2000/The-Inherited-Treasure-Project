using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFlap : MonoBehaviour
{
    private float RotationSpeed = 50.0f;
    //private float MovementSpeed = 1.0f;
    private bool opened;
    private float rotation;
    private bool desireToOpen;

    void Start()
    {
        if (gameObject.name.Contains("2"))
        {
            RotationSpeed = -50.0f;
        }
        opened = false;
    }

    
    void Update()
    {
        changeDoorStateAnimation();
    }

    private void changeDoorStateAnimation() {
        if (!opened && desireToOpen)
        {
            openAnimation();
        }
        else if(opened && !desireToOpen)
        {
            closeAnimation();
        }
    }

    private void openAnimation()
    {
        rotation = this.gameObject.transform.localRotation.eulerAngles.y;
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
        //transform.Translate(MovementSpeed * Time.deltaTime, 0, 0, Space.Self);
        if (RotationSpeed>0) {
            if (rotation >= 74) { setOpened(); }
        }
        else {
            if (rotation <= 286 && rotation != 0) { setOpened(); }
        }
    }

    private void closeAnimation()
    {
        rotation = this.gameObject.transform.localRotation.eulerAngles.y;
        transform.Rotate(0, -RotationSpeed * Time.deltaTime, 0);
        //transform.Translate(MovementSpeed * Time.deltaTime, 0, 0, Space.Self);
        if (RotationSpeed > 0)
        {
            if (rotation <= 1) { setOpened(); }
        }
        else
        {
            if (rotation >= 359) { setOpened(); }
        }
    }

    private void setOpened() {
        opened = !opened;
    }

    public void changeDoorState(bool state) {
        desireToOpen = state;
    }
}
