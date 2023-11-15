using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float gameTime = 0f;

    void Update()
    {
        gameTime += Time.deltaTime;
    }
}
