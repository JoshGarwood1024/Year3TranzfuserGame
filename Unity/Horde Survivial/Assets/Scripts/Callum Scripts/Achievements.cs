using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Total Enemies Killed") >= 20)
        {
            Debug.Log("Achievement unlocked, killed 20 enemies");
        }

        if (PlayerPrefs.GetInt("Total Time Survived4") >= 50 )
        {
            Debug.Log("Achievement unlocked, survived for 20 seconds");
        }
    }
}
