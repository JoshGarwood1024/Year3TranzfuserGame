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
        Time.timeScale = 0;
    }

    private void Update()
    {

    }

    // Public method to start the fade-out when called.
    public void FadeOut()
    {
        // Reset the alpha value.
        currentAlpha = 1.0f;
        // Enable the GameObject in case it was disabled previously.
        gameObject.SetActive(true);
        // Call the coroutine for smoother fading.
        StartCoroutine(FadeOutCoroutine());
    }

    // Coroutine for smoother fading.
    private IEnumerator FadeOutCoroutine()
    {
        while (currentAlpha > 0.0f)
        {
            currentAlpha -= Time.deltaTime / fadeDuration;
            image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);
            yield return null;
        }

        // After the fade-out is complete, you can disable the GameObject.
        gameObject.SetActive(false);
    }
}
