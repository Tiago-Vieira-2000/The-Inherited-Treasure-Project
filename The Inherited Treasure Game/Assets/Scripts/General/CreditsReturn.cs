using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsReturn : MonoBehaviour
{
    public GameObject menu;
    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("MainMenu");
    }

    public void CloseMainMenu()
    {
        menu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(menu.activeInHierarchy == false)
            {
                menu.SetActive(true);            }
            

        }
    }
}
