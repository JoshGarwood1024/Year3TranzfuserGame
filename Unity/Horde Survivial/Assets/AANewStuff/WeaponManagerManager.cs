using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagerManager : MonoBehaviour
{
    public GameObject Head1;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Total Time Survived4") >= 10)
        {
            Head1.GetComponent<BalloonBombs>().enabled = true;
            if (PlayerPrefs.GetInt("Achievement1UnlockedAlready") == 0)
            {
                //PlayerPrefs.SetInt("Achievement1UnlockedAlready", (PlayerPrefs.GetInt("Achievement1UnlockedAlready") + 1));


            }
        }
        else
        {
            Head1.GetComponent<BalloonBombs>().enabled = false;
        }
        // Update is called once per frame
    }
}