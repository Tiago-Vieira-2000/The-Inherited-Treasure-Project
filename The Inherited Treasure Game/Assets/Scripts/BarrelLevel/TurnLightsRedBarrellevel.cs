using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightsRedBarrellevel : MonoBehaviour
{
    public void characterDied(string name)
    {
        Debug.Log("Enter");
        turnLightsRed(name);
    }

    void turnLightsRed(string name)
    {
        
        Light[] lights;
        lights = FindObjectsOfType(typeof(Light)) as Light[];
        foreach (Light light in lights)
        {
            if (light.name.Contains(name.Remove(0, 6)))
            {
                light.color = Color.red;
            }
        }
    }
}
