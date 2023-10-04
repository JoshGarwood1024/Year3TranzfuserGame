using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{

    //OBVIOUSLY A VERY TEMP HARD CODED SCRIPT JUST TO SHOW WHAT WILL BE ADDED TO THE FUTURE

    public GameObject shotgun;
    public GameObject upgradePanel;
    public GameObject player;

    private float timeToSpawn = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToSpawn <= 0.0f && !player.GetComponent<PlayerShooting>().shotgun)
        {
            Time.timeScale = 0.0f;
            upgradePanel.SetActive(true);
            timeToSpawn = 8.0f;
        }
        else
        {
             timeToSpawn -= Time.deltaTime;
        }
    }

    public void BoughtShotgun()
    {
        shotgun.SetActive(true);
        player.GetComponent<PlayerShooting>().shotgun = true;
        ResetTimeScale();
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1.0f;
    }
}
