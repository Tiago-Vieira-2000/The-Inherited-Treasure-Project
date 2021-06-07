using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private string doorName;

    /// <summary>
    /// Method that starts the Door
    /// </summary>
    void Start()
    {
        doorName = gameObject.name;
    }

    /// <summary>
    /// Method responsable for changing the state of both DoorFlaps
    /// </summary>
    /// <param name="state">If the door needs to be open</param>
    public void changeDoorState(bool state) {
        GameObject.Find(doorName + "/door 1").GetComponent<DoorFlap>().changeDoorState(state);
        GameObject.Find(doorName + "/door 2").GetComponent<DoorFlap>().changeDoorState(state);
    }
}
