using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putGemonPedestal : MonoBehaviour
{
    public GameObject detectorP;
    private bool hasGem;
    public GameObject Gem;
    public Light light;
    // Start is called before the first frame update
    /// <summary>
    /// Initialize the variables
    /// </summary>
    void Start()
    {
        Gem.SetActive(false);
        hasGem = false;
    }

    // Update is called once per frame
    /// <summary>
    /// When a character stands in front of the pedestal, put the gem inside, and prevent that character from moving any further.
    /// </summary>
    void Update()
    {
        if(detectorP.GetComponent<playerDetector>().EnteredTrigger){
            if(!hasGem){
                GameObject playerDetected = detectorP.GetComponent<playerDetector>().CollisionWith;
                if(playerDetected.GetComponent<player>().hasGem){
                    Debug.Log("Pedestal recebeu a Gema");
                    playerDetected.GetComponent<player>().rb.isKinematic = true;
                    playerDetected.GetComponent<player>().Gem.SetActive(false);
                    playerDetected.GetComponent<moveGrid>().enabled = false;
                    playerDetected.GetComponent<PlayerChess>().enabled = false;
                    Gem.SetActive(true);
                    hasGem = true;
                    playerDetected.GetComponent<player>().hasGem = false;
                    light.GetComponent<Light>().enabled = true;
                }
            }
        }
    }
}
