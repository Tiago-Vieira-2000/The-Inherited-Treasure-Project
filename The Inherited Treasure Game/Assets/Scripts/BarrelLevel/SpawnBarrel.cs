using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarrel : MonoBehaviour
{

    public GameObject barrelPrefab;
    public float minTime = 0;
    public float maxTime = 0;
    private float timer = 0;
    public float x = 0;
    public float y = 0;
    public float z = 0;

 
    // Update is called once per frame
    void Update()
    {
        float randomTime = Random.Range(minTime, maxTime);
        Debug.Log("Random Time: " + randomTime);
        if(timer >= randomTime)
        {
           
            GameObject barrel = Instantiate(barrelPrefab);
            barrel.transform.position = transform.position = new Vector3(x, y, z);
            timer = 0;
            
        }

        timer += Time.deltaTime;
    }
}
