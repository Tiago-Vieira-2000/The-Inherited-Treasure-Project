using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightsRedBarrellevel : MonoBehaviour
{
    /// <summary>
    /// When a character dies, the pathway where the player was turns red
    /// </summary>
    /// <param name="name"></param>
    public void characterDied(string name)
    {
        Debug.Log("Enter");
        turnLightsRed(name);
    }

    /// <summary>
    /// Turns pathway lights red
    /// </summary>
    /// <param name="name"></param>
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
