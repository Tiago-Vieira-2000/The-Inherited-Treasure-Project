using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putGemonPedestal : MonoBehaviour
{
    public GameObject detectorP;
    private bool hasGem;
    public GameObject Gem;
    // Start is called before the first frame update
    void Start()
    {
        Gem.SetActive(false);
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
                    playerDetected.GetComponent<player>().Gem.SetActive(false);
                    Gem.SetActive(true);
                    hasGem = true;
                }
            }
        }
    }
}
