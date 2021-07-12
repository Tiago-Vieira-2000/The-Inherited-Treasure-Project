using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popupBox;
    public Text popUpDesc;

    public void PopUp(string text)
    {
        popupBox.SetActive(true);
        popUpDesc.text = text;
    }

    public void Leave()
    {
        Application.Quit();
    }
}
