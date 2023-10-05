using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;

    private float startTime;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "00:00";
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        time = Mathf.Round(Time.time - startTime);
        float minutes = (time / 60);
        float seconds = (time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
