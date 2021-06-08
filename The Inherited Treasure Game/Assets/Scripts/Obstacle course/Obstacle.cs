using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private string obstacleName;

    void Start()
    {
        obstacleName = gameObject.name;
    }
        
    void Update()
    {
        switch (obstacleName) {
            case "Cylinder":
                cylinder();
                break;
            case "Swinging Platform":
                swingingPlatform();
                break;
            case "Ghost Platform":
                ghostPlatform();
                break;
            case "Fragile platform":
                fragilePlatform();
                break;
            case "S-rotate platform":
                slowRotatePlatform();
                break;
            case "F-rotate Platform":
                fastRotatePlatform();
                break;
            default:
                liftPlatform();
                break;
        }
    }

    private void liftPlatform()
    {
        
    }

    private void fastRotatePlatform()
    {
        
    }

    private void slowRotatePlatform()
    {
        
    }

    private void fragilePlatform()
    {
        
    }

    private void ghostPlatform()
    {
        
    }

    private void swingingPlatform()
    {
        
    }

    private void cylinder()
    {
        
    }
}
