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

    public void changeDoorState() {
        GameObject.Find(doorName + "/door 1").GetComponent<DoorFlap>().changeDoorState();
        GameObject.Find(doorName + "/door 2").GetComponent<DoorFlap>().changeDoorState();
    }
}
