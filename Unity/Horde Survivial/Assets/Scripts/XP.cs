using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XP : MonoBehaviour
{
    public static float LVLXP = 0;
    public float startXP;
    public Image XPbar;

    // Start is called before the first frame update
    void Start()
    {
        LVLXP = 0;
    }

    // Update is called once per frame
    void Update()
    {
        XPbar.fillAmount = LVLXP / startXP;
    }
}
