using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;
    public int score = 0;
    public Animator anim;
    public RuntimeAnimatorController jumpController;
    public RuntimeAnimatorController idleController;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = idleController;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);

        rb.AddForce(movement * speed);

       
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.runtimeAnimatorController = jumpController as RuntimeAnimatorController;
                if (this.gameObject.transform.position.y < 0.20000)
                {
                    anim.runtimeAnimatorController = idleController;
                    rb.AddForce(new Vector3(0, 3f, 0), ForceMode.Impulse);
                }
            }
        

    }
}

