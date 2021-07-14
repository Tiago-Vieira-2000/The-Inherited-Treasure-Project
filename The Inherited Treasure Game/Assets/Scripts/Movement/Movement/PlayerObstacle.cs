using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacle : MonoBehaviour
{
    public MindObstacle mind;
    int layer_mask;

    private void Start()
    {
        layer_mask = LayerMask.GetMask("Player");
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer_mask))
            {
                if (hit.transform != null)
                {
                    mind.changePlayer(hit.transform.gameObject);
                    Debug.Log(hit);
                    //this.gameObject.GetComponent<NewBehaviourScript>().enabled = true;

                }
                Debug.Log("Hit" + hit.transform.name);
            }

        }
    }
}
