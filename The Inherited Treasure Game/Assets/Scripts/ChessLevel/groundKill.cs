using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundKill : MonoBehaviour
{
    public int percentage;
    public GameObject detectorP;
    private int randomN;
    private bool done;
    // Start is called before the first frame update
    /// <summary>
    /// Initialize the variables
    /// </summary>
    void Start()
    {
        done = false;
    }

    // Update is called once per frame
    /// <summary>
    /// Each time a player steps on a black square, a die from 1 to 100 is rolled, if the number taken is less than the column percentage, the character dies
    /// </summary>
    void Update()
    {
        if(detectorP.GetComponent<playerDetector>().EnteredTrigger){
            if(!done){
                randomN = Random.Range(1,101);
                Debug.Log("Número tirado: " + randomN);
                if(randomN<percentage){
                    Destroy(detectorP.GetComponent<playerDetector>().CollisionWith);
                    Debug.Log("Personagem Morreu pelo chão");
                }
                done = true;
            }
            
        }
    }
}
