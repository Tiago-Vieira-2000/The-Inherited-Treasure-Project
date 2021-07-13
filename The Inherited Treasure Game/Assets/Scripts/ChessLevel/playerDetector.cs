using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetector : MonoBehaviour
{
    public bool EnteredTrigger;
    public GameObject CollisionWith;  
  
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            EnteredTrigger = true;
            CollisionWith = other.gameObject;
            Debug.Log("Jogador Detetado");
        }
            
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player"){
             EnteredTrigger = false;
            CollisionWith = null;
        } 
    }
}
