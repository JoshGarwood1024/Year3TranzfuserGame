using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCount : MonoBehaviour
{

    public static int scoreValue = 0;
    public TMP_Text LevelScore;

    // Start is called before the first frame update
    void Start()
    {
        LevelScore = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        LevelScore.text = scoreValue.ToString();
    }
}
