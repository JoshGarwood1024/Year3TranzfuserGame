using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public GameObject Head1;
    public GameObject Head2;
    public GameObject Head3;
    public GameObject eeee;
    PopupScript PuPs;
    private GameObject window;
    private Animator popupanim;
    public AudioSource audioSource;
    public AudioClip achieveUnlocked;




    // Start is called before the first frame update
    void Start()
    {
        window = transform.GetChild(0).gameObject;
        popupanim = window.GetComponent<Animator>();
       
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
            if (PlayerPrefs.GetInt("Total Time Survived4") >= 10)
            {
                if (PlayerPrefs.GetInt("Achievement1UnlockedAlready") == 0)
                    {
                    //PlayerPrefs.SetInt("Achievement1UnlockedAlready", (PlayerPrefs.GetInt("Achievement1UnlockedAlready") + 1));
                    Head1.SetActive(true);
                    Debug.Log("Achievement unlocked, survived for 20 seconds");
                    AudioManager.instance.PlayMusic(achieveUnlocked);



                }

            }
            if (PlayerPrefs.GetInt("Total Time Survived4") < 10)
            {
                Head1.SetActive(false);
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
