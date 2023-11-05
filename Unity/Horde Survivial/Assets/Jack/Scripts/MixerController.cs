using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer myAudioMixer;

    public Slider musicSlider;
    public Slider sfxSlider;
    public TextMeshProUGUI musicText;
    public TextMeshProUGUI sfxText;

    private void Start()
    {
        SetSliders();
    }

    public void SetVolumeMusic(float sliderValue)
    {
        myAudioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        PlayerPrefs.Save();
    }
    public void SetVolumeEffects(float sliderValue)
    {
        myAudioMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
        PlayerPrefs.Save();
    }

    void SetSliders()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void MusicText(float sliderValue)
    {
        musicText.text = sliderValue.ToString("0.00");
    }

    public void SFXText(float sliderValue)
    {
        sfxText.text = sliderValue.ToString("0.00");
    }
}
