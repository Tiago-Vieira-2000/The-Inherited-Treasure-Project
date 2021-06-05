using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarrel : MonoBehaviour
{

    public GameObject[] barrelPrefab;
    public float spawnTime = 1;
    private float timer = 0;
    public float x = 0;
    public float y = 0;
    public float z = 0;
    private Vector3 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    // Update is called once per frame
    void Update()
    {
        if(timer > spawnTime)
        {
            int rand = Random.Range(0, barrelPrefab.Length);
           
            GameObject barrel = Instantiate(barrelPrefab[rand]);
            barrel.transform.position = transform.position = new Vector3(x, y, z);
            Destroy(barrel, 15);
            timer = 0;
            if(transform.position.z < screenBounds.z)
            {
                Destroy(this.gameObject);
            }
        }

        timer += Time.deltaTime;
    }
}
