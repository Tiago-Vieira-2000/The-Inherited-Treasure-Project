using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Platform").GetComponent<ObstacleCourseGame>().characterDied(other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}
