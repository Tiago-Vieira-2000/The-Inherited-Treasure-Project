using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statue1 : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 5;
    int startDegree = 180;
    int endDegree =0;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Provisório para testar as rotações
        if (time > 0)
        {
            time -= Time.deltaTime;
            Debug.Log(Mathf.Round(time).ToString());
            transform.Rotate (0,50*Time.deltaTime,0); //roda 50 graus por segundo no eixo do y
        }
        else
        {
            endDegree = pattern1(startDegree);
            startDegree = endDegree;
            enabled = false;
            Debug.Log("Fim da Ronda");
        }
        
    }

    int pattern1(int degree){
        //45 graus para cada movimento
        //padrão estátuda 1 : +3
        degree = degree + 135;
        Debug.Log(degree);
        transform.rotation = Quaternion.Euler(0, degree, 0);
        return degree;
    }
}
