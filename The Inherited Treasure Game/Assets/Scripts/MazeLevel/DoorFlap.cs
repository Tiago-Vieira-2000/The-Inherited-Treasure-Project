using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DoorFlap is a half of a double door.
/// </summary>
public class DoorFlap : MonoBehaviour
{
    private float RotationSpeed;
    private float MovementSpeed;
    private bool opened;
    private float rotation;
    private bool desiredState;
    private bool moving;

    /// <summary>
    /// Method that starts the DoorFlap closed and still.
    /// The direction of the rotation will depend on the which half of the Door it is.
    /// </summary>
    void Start()
    {
        MovementSpeed = 0.5f;
        if (gameObject.name.Contains("2"))
        {
            RotationSpeed = -50.0f;
        }
        else {
            RotationSpeed = 50.0f;
        }
        opened = false;
        moving = false;
    }

    /// <summary>
    /// Method responsable for contantly checking if the DoorFlap needs to open.
    /// desiredState -> If the game logic says that the DoorFlap needs to be open
    /// opened       -> If the DoorFlap is open
    /// moving       -> If the DoorFlap is still opening or closing
    /// </summary>
    void Update()
    {
        if (desiredState && !opened)
        {
            open();
        }
        else if (moving || (!desiredState && opened))
        {
            close();
        }
    }

    /// <summary>
    /// Method responsable for opening the DoorFlap
    /// </summary>
    private void open()
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

    /// <summary>
    /// Method responsable for closing the DoorFlap
    /// </summary>
    private void close()
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

    /// <summary>
    /// This method is used when the DoorFlap is completly still and open or closed
    /// </summary>
    /// <param name="state">If the door is open</param>
    private void setOpened(bool state) {
        opened = state;
        moving = false;
    }

    /// <summary>
    /// Method responsable for updating the state that game logic wants the DoorFlap to be in
    /// </summary>
    /// <param name="state">If the game logic says that the DoorFlap needs to be open</param>
    public void changeDoorState(bool state) {
        desiredState = state;
    }
}
