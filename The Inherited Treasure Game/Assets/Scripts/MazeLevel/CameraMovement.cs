using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float location;
    
    void Update()
    {
        updateLocation();
        transform.position = new Vector3(transform.position.x, transform.position.y, location);
    }

    /// <summary>
    /// Method that updates the location of tha camera
    /// </summary>
    private void updateLocation() {
        location = 0;
        int characterAmount = 0;
        try
        {
            location += GameObject.Find("Player" + 1).transform.position.z;
            characterAmount++;
        }
        catch (System.NullReferenceException)
        {
            
        }

        try
        {
            location += GameObject.Find("Player" + 2).transform.position.z;
            characterAmount++;
        }
        catch (System.NullReferenceException)
        {
            
        }

        try
        {
            location += GameObject.Find("Player" + 3).transform.position.z;
            characterAmount++;
        }

        catch (System.NullReferenceException)
        {
            
        }

        try
        {
            location += GameObject.Find("Player" + 4).transform.position.z;
            characterAmount++;
        }
        catch (System.NullReferenceException)
        {
            
        }
        if (characterAmount>0)
        {
            location /= characterAmount;
        }
        else
        {
            location = 0;
        }   
    }
}
