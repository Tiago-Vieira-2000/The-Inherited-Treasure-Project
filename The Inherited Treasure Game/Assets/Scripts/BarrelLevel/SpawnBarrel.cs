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

 
    /// <summary>
    /// Every time a barrel is spawned, a random location will be selected and the barrel will spawn from that new location
    /// </summary>
    void Update()
    {
        float randomTime = Random.Range(minTime, maxTime);
        Vector3 pos1 = new Vector3(8, 0, 12);
        Vector3 pos2 = new Vector3(4, 0, 12);
        Vector3 pos3 = new Vector3(0, 0, 12);
        Vector3 pos4 = new Vector3(-4 ,0, 12);

        if (timer >= randomTime)
        {
            int randomSpawn = Random.Range(1, 5);
            GameObject barrel = Instantiate(barrelPrefab);
            barrel.transform.position = this.gameObject.transform.position;
            if(randomSpawn == 1)
            {
                Debug.Log("Enter: ");
                this.gameObject.transform.position = pos1;
            }
            else if(randomSpawn == 2)
            {
                Debug.Log("Enter: ");
                this.gameObject.transform.position = pos2;
            }
            else if (randomSpawn == 3)
            {
                Debug.Log("Enter: ");
                this.gameObject.transform.position = pos3;
            }
            else if (randomSpawn == 4)
            {
                Debug.Log("Enter: ");
                this.gameObject.transform.position = pos4;
            }

            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
