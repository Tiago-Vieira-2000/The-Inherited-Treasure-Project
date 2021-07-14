using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetector : MonoBehaviour
{
    public bool EnteredTrigger;
    public GameObject CollisionWith;  
  
    /// <summary>
    /// Detects if a character has entered your area
    /// </summary>
    /// <param other="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            EnteredTrigger = true;
            CollisionWith = other.gameObject;
            Debug.Log("Jogador Detetado");
        }
            
    }
    /// <summary>
    /// Detects if a character leaves your area
    /// </summary>
    /// <param other="other"></param>
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player"){
             EnteredTrigger = false;
            CollisionWith = null;
        } 
    }
}
