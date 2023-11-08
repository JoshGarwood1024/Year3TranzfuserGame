using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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
            if (TryGetComponent<Light2D>(out Light2D l)) l.intensity = timer / FadeOutTime;
            timer -= Time.deltaTime;
        }
    }
}
