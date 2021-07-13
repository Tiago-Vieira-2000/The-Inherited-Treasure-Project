using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statue3 : MonoBehaviour
{
    // Start is called before the first frame update
    private float time = 5;
    private float RotationSpeed = 50.0f;
    private int[] arrayDegree;
    private int currentDegree;
    private int startDegree = 270;
    //private int endDegree =0;
    public Rigidbody rb;
    private bool moving;
    private bool math;
    private bool done;
    public bool hasGem;
    public GameObject detectorF;
    public GameObject detectorB;
    public GameObject Gem;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moving = true;
        math = false;
        done = false;
        hasGem= true;
        //Variável para escolher aleatóriamente o padrão de rotação
        var randomInt = Random.Range(1,4);
        if(randomInt==1){
            arrayDegree= new int[3] {-45, -90, -90};
        }
        else if(randomInt==2){
            arrayDegree= new int[3] {-135, 0, -90};
        }
        else if(randomInt==3){
            arrayDegree= new int[3] {135, 180, 180};
        }
        currentDegree = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Provisório para testar as rotações
        if (time > 0)
        {
            time -= Time.deltaTime;
            //Debug.Log(Mathf.Round(time).ToString());
            transform.Rotate (0,RotationSpeed * Time.deltaTime,0); //roda 50 graus por segundo no eixo do y
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

    private void pattern(int degree){
        float rotation = this.gameObject.transform.localRotation.eulerAngles.y;
        if(moving){
            //Debug.Log(rotation);
            //Debug.Log(degree);
            transform.Rotate (0,RotationSpeed * Time.deltaTime,0);
            if(stop((int)rotation, degree)){
                transform.Rotate (0,0,0);
                moving= false;
                transform.rotation = Quaternion.Euler(0, degree, 0);
                Debug.Log("Parou");
            }
        }
    }

    bool stop(int rotation, int degree) {
        if (rotation == degree){
            return true;
        }
        return false;
    }

    private void checkKill(){
        if(detectorF.GetComponent<playerDetector>().EnteredTrigger){
            if(!moving && !done){
                Destroy(detectorF.GetComponent<playerDetector>().CollisionWith);
                Debug.Log("Personagem Morreu pela estátua");
                done=true;
            }
        }
    }   
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
