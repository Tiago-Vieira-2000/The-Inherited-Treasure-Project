using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popupBox;
    public Text popUpDesc;

    /// <summary>
    /// Shows popUp Box
    /// </summary>
    /// <param name="text"></param>
    public void PopUp(string text)
    {
        popupBox.SetActive(true);
        popUpDesc.text = text;
    }

    /// <summary>
    /// Leaves popUp Box
    /// </summary>
    public void Leave()
    {
        Application.Quit();
    }
}
