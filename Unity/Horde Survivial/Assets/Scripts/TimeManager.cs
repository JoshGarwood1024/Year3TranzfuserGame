using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
     public float gameTime = 0f;
    public float gameTimeInSeconds = 0;
    private float timer;


    void Update()
    {
        gameTime += Time.deltaTime;
        timer += Time.deltaTime;
        gameTimeInSeconds += (gameTime/600);
        if (timer > 1f)
        {
            SetTotalTimeSurvived();
            timer = 0f;
        }

    }

    public void SetHighscore()
    {
        PlayerPrefs.SetInt("Highscore", (int)gameTime);
    }

    public void SetTotalTimeSurvived()
    {
        PlayerPrefs.SetInt("Total Time Survived4", (PlayerPrefs.GetInt("Total Time Survived4") + 1));
    }
}