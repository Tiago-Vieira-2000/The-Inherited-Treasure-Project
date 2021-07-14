using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statue1 : MonoBehaviour
{
    // Start is called before the first frame update
    private float time;
    private float RotationSpeed;
    private int startDegree;
    //private int endDegree =0;
    public Rigidbody rb;
    private bool moving;
    private bool math;
    private bool done;
    public bool hasGem;
    public GameObject detectorF;
    public GameObject detectorB;
    public GameObject Gem;
    /// <summary>
    /// Initialize the variables
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        time = 5;
        RotationSpeed = 50.0f;
        startDegree = 270;
        moving = true;
        math = false;
        done = false;
        hasGem= true;
    }

    // Update is called once per frame
    /// <summary>
    /// While the statues rotate, the player moves the characters, when they are all moved, the statues stop and check if any action was triggered
    /// </summary>
    void Update()
    {
        //Provisório para testar as rotações
        if (time > 0)
        {
            time -= Time.deltaTime;
            //Debug.Log(Mathf.Round(time).ToString());
            transform.Rotate (0,0,RotationSpeed * Time.deltaTime); //roda 50 graus por segundo no eixo do y
        }
        else
        {
            if(!math){
                startDegree+= 135;
                if(startDegree>= 360){
                    startDegree= startDegree-360;
                }
                math= true;
            }
            pattern(startDegree);
            checkKill();
            checkGem();
        }
        
    }

    /// <summary>
    /// Make the statue rotate according to its pattern
    /// </summary>
    /// <param degree="degree"></param>
    private void pattern(int degree){
        float rotation = this.gameObject.transform.localRotation.eulerAngles.y;
        if(moving){
            //Debug.Log(rotation);
            //Debug.Log(degree);
            transform.Rotate (0,0,RotationSpeed * Time.deltaTime);
            if(stop((int)rotation, degree)){
                transform.Rotate (0,0,0);
                moving= false;
                transform.rotation = Quaternion.Euler(-90, 0, degree);
                Debug.Log("Parou");
            }
        }
    }

    /// <summary>
    /// Check if the statue has reached the expected angle
    /// </summary>
    /// <param rotation="rotation"></param>
    /// <param degree="degree"></param>
    bool stop(int rotation, int degree) {
        if (rotation == degree){
            return true;
        }
        return false;
    }

    /// <summary>
    /// Check if any characters are in front of the statue
    /// </summary>
    private void checkKill(){
        if(detectorF.GetComponent<playerDetector>().EnteredTrigger){
            if(!moving && !done){
                Destroy(detectorF.GetComponent<playerDetector>().CollisionWith);
                Debug.Log("Personagem Morreu pela estátua");
                done=true;
            }
        }
    }   

    /// <summary>
    /// Check if any characters are behind the statue
    /// </summary>
    private void checkGem(){
        if(detectorB.GetComponent<playerDetector>().EnteredTrigger){
            if(!moving && !done && hasGem){
                GameObject playerDetected = detectorB.GetComponent<playerDetector>().CollisionWith;
                if(playerDetected.GetComponent<player>().hasGem){
                    Debug.Log("Esta Personagem já tem uma gema");
                }
                else
                {
                    Debug.Log("Personagem Apanhou a Gema");
                    playerDetected.GetComponent<player>().Gem.SetActive(true);
                    playerDetected.GetComponent<player>().hasGem = true;
                    
                    Gem.SetActive(false);
                    hasGem=false;
                }
                done=true;
            }
        }
    }
}
