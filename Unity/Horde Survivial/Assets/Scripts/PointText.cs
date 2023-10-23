using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointText : MonoBehaviour
{
    public float FadeOutTime;
    private float timer;

    private TextMeshProUGUI text;

    private void Start()
    {
        timer = FadeOutTime;
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        transform.position += new Vector3(0.01f, 0.02f, 0);

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Color c = new Color(text.color.r, text.color.g, text.color.b, timer / FadeOutTime);
            text.color = c;
            timer -= Time.deltaTime;
        }
    }
}
