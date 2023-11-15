using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TimeManager timeManager; // Reference to the TimeManager script

    void Update()
    {
        if (timeManager != null && timeText != null)
        {
            // Access the gameTime variable from the TimeManager script
            float currentTime = timeManager.gameTime;

            // Format the time with minutes and seconds
            string formattedTime = FormatTime(currentTime);

            // Display the formatted time in the UI TextMeshProUGUI component
            timeText.text = " " + formattedTime;
        }

    }

    // Updated: Format the time as minutes and seconds
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);

        return string.Format("{00:00}:{1:00}", minutes, seconds);
    }
}
