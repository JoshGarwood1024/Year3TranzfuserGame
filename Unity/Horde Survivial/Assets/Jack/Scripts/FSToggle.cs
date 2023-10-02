using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSToggle : MonoBehaviour
{
    public void Change()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("Fullscreen");
    }
}
