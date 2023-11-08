using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeOut : MonoBehaviour
{
    public float fadeDuration = 2.0f; 
    private float currentAlpha = 1.0f; 

    private Image image; 

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        currentAlpha -= Time.deltaTime / fadeDuration;
        image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);

        if (currentAlpha <= 0.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
