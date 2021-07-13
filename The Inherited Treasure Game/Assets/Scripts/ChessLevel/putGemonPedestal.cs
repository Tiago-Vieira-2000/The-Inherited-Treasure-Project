using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putGemonPedestal : MonoBehaviour
{
    public GameObject detectorP;
    private bool hasGem;
    // Start is called before the first frame update
    void Start()
    {
        hasGem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(detectorP.GetComponent<playerDetector>().EnteredTrigger){
            if(!hasGem){
                GameObject playerDetected = detectorP.GetComponent<playerDetector>().CollisionWith;
                if(playerDetected.GetComponent<player>().hasGem){
                    Debug.Log("Pedestal recebeu a Gema");
                    playerDetected.GetComponent<player>().rb.isKinematic = true;
                    hasGem = true;
                }
            }
        }
    }
}
