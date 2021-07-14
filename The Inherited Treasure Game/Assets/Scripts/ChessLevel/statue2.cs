using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statue2 : MonoBehaviour
{
    // Start is called before the first frame update
    private float time;
    private float RotationSpeed;
    private int[] arrayDegree;
    private int currentDegree;
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
        RotationSpeed = 50.0f;
        startDegree = 270;
        time = 5;
        moving = true;
        math = false;
        done = false;
        hasGem= true;
        //Variável para escolher aleatóriamente o padrão de rotação
        var randomInt = Random.Range(1,3);
        if(randomInt==1){
            arrayDegree= new int[2] {180, -45};
        }
        else if(randomInt==2){
            arrayDegree= new int[2] {-90, 135};
        }
        
        currentDegree = 0;
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
                startDegree+= arrayDegree[currentDegree];
                if(startDegree>= 360){
                    startDegree= startDegree-360;
                }
                math= true;
                currentDegree++;
                if(currentDegree == arrayDegree.Length){
                    currentDegree=0;
                }
                
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
                    playerDetected.GetComponent<player>().hasGem = true;
                    playerDetected.GetComponent<player>().Gem.SetActive(true);
                    Gem.SetActive(false);
                    hasGem=false;
                }
                done=true;
            }
        }
    }
}
