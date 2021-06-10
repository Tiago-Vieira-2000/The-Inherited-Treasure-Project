using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarrel : MonoBehaviour
{

    public GameObject[] barrelPrefab;
    float minTime = 1;
    float maxTime = 10;
    private float timer = 0;
    public float x = 0;
    public float y = 0;
    public float z = 0;

 
    // Update is called once per frame
    void Update()
    {
        float randomTime = Random.Range(minTime, maxTime);
        if(timer > randomTime)
        {
            int rand = Random.Range(0, barrelPrefab.Length);
           
            GameObject barrel = Instantiate(barrelPrefab[rand]);
            barrel.transform.position = transform.position = new Vector3(x, y, z);
            timer = 0;
            
        }

        timer += Time.deltaTime;
    }
}
