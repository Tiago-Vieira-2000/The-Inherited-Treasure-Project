using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGrid : MonoBehaviour
{
    public float maxDistance = 13f;
    GameObject destination;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform != null)
                {
                  destination = hit.transform.gameObject;
                  Debug.Log("Distance: " + Vector3.Distance(transform.position, destination.transform.position));
                  if(Vector3.Distance(transform.position, destination.transform.position) <= maxDistance)
                  {
                        this.gameObject.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
                  }
                  else
                  {
                        Debug.Log("Not in distance");
                  }
                }            }

        }
    }
}
