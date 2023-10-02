using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResOptions : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    private void Start()
    {
        Resolution[] resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> resolutionOptions = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resolutionOptions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution[] resolutions = Screen.resolutions;
        if (resolutionIndex >= 0 && resolutionIndex < resolutions.Length)
        {
            Resolution selectedResolution = resolutions[resolutionIndex];
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
        }
    }
}