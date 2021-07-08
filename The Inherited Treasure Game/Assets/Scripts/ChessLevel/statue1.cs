using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statue1 : MonoBehaviour
{
    // Start is called before the first frame update
    private float time = 5;
    private float RotationSpeed = 50.0f;
    private int startDegree = 180;
    //private int endDegree =0;
    private float rotation;
    public Rigidbody rb;
    private bool moving;
    private bool math;
    public GameObject detector3;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moving = true;
        math = false;
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
                startDegree+= 135;
                math= true;
            }
            pattern(startDegree);
            //startDegree = endDegree;
            //enabled = false;
            //Debug.Log("Fim da Ronda");
            checkKill(startDegree);
        }
        
    }

    private void pattern(int degree){
        //45 graus para cada movimento
        //padrão estátuda 1 : +3
        rotation = this.gameObject.transform.localRotation.eulerAngles.y;
        //degree = degree + 135;
        if(moving){
            //Debug.Log(rotation);
            //Debug.Log(degree);
            transform.Rotate (0,RotationSpeed * Time.deltaTime,0);
            if(rotation>=degree){
                 transform.Rotate (0,0,0);
                 moving= false;
                 transform.rotation = Quaternion.Euler(0, degree, 0);
                 Debug.Log("Parou");
            }
        }
        //transform.rotation = Quaternion.Euler(0, degree, 0);     
       
        //startDegree = degree;
        //Debug.Log(degree);
        //return degree;
    }
    private void checkKill(int degree){
        if(detector3.GetComponent<playerDetector>().EnteredTrigger){
            if(degree == 315 && !moving){
                Destroy(detector3.GetComponent<playerDetector>().CollisionWith);
                Debug.Log("Personagem Morreu");
            }
        }
        

    }
}
