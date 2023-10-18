using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float FadeOutTime;
    private float timer;

    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        timer = FadeOutTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            Destroy(gameObject);
        } else
        {
            Color c = new Color(sr.color.r, sr.color.g, sr.color.b, timer / FadeOutTime);
            sr.color = c;
            timer -= Time.deltaTime;
        }
    }
}
