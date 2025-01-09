using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class sliderManager : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider volumeSlider;
    public Slider brightnessSlider;
    public Slider sensitivitySlider;
    public CanvasGroup brightnessPanel;
    //public playerRotation playerRotationClass;

    void Start()
    {
        if (PlayerPrefs.HasKey("saveVolume"))
        {
            loadVolume();
        }
        else
        {
            setMusicVolume();
        }

        if (PlayerPrefs.HasKey("saveBrightness"))
        {
            loadBrightness();
        }
        else
        {
            setBrightness();
        }

        if (PlayerPrefs.HasKey("saveSensitivity"))
        {
            loadSensitivity();
        }
        else
        {
            setSensitivity();
        }
    }

    public void setMusicVolume()
    {
        float volume = volumeSlider.value;
        mixer.SetFloat("bgMusic", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("saveVolume", volume);
    }

    private void loadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("saveVolume");
        setMusicVolume();
    }

    public void setBrightness()
    {
        float brightness = brightnessSlider.value;
        brightnessPanel.alpha = Mathf.Abs((brightness-1.0f)/2.0f); 
        PlayerPrefs.SetFloat("saveBrightness", brightness);
    }

    private void loadBrightness()
    {
        brightnessSlider.value = PlayerPrefs.GetFloat("saveBrightness");
        setBrightness();
    }

    public void setSensitivity()
    {
        float sensitivity = sensitivitySlider.value;
        playerRotation.turnSmoothTime = Mathf.Abs((sensitivity - 1.0f) + 0.1f);
        PlayerPrefs.SetFloat("saveSensitivity", sensitivity);
    }

    private void loadSensitivity()
    {
        sensitivitySlider.value = PlayerPrefs.GetFloat("saveSensitivity");
        setSensitivity();
    }

}
