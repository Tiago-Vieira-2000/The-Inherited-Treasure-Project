using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private string doorName;
    void Start()
    {
        doorName = gameObject.name;
    }
    
    void Update()
    {
        
    }

    public void changeDoorState(bool state) {
        GameObject.Find(doorName + "/door 1").GetComponent<DoorFlap>().changeDoorState(state);
        GameObject.Find(doorName + "/door 2").GetComponent<DoorFlap>().changeDoorState(state);
    }
}
