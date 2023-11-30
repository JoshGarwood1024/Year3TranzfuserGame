using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public GameObject Head1;
    public GameObject Head2;
    public GameObject Head3;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void resetAchievement()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        if(Head1)
        {
            if (PlayerPrefs.GetInt("Total Time Survived4") >= 50)
            {
                Head1.SetActive(true);
                Debug.Log("Achievement unlocked, survived for 20 seconds");
            }
            if (PlayerPrefs.GetInt("Total Time Survived4") < 50)
            {
                Head1.SetActive(false);
                Debug.Log("Achievement unlocked, survived for 20 seconds");
            }
        }


        if(Head2)
        {
            if (PlayerPrefs.GetInt("Total Enemies Killed") >= 20)
            {
                Head2.SetActive(true);
                Debug.Log("Achievement unlocked, killed a total of 20 enemies");
            }

            if (PlayerPrefs.GetInt("Total Enemies Killed") < 20)
            {
                Head2.SetActive(false);
                Debug.Log("Achievement unlocked, killed a total of 20 enemies");
            }
        }
    }
}
