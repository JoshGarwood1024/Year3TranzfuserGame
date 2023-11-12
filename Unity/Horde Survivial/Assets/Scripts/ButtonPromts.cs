using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPromts : MonoBehaviour
{
    public GameObject Buttons;



    public void buttonOn()
    {
        Buttons.SetActive(true);
    }

    public void ButtonOff()
    {
        Buttons.SetActive(false);
    }


}
