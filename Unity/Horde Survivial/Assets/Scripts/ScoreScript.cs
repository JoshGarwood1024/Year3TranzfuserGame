using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;

    public TMP_Text Score;

    void Start()
    {
        Score = GetComponent<TMP_Text>();
    }

    void Update()
    {


        Score.text = "X " + scoreValue;
    }

    public void GoBack()
    {
        scoreValue = 0;
    }



}
