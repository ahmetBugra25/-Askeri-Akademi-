using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AyarlarSes : MonoBehaviour
{
    public Text volumeDeger;

    public Slider slider;

    private void Start()
    {
        LoadAudio();
    }

    public void SetAudio(float value)
    {
        AudioListener.volume = value;
        volumeDeger.text = ((int)(value * 100)).ToString();
        SaveAudio();
    }

    private void SaveAudio()
    {
        PlayerPrefs.SetFloat("audioVolume",AudioListener.volume);
    }

    private void LoadAudio()
    {
        if (PlayerPrefs.HasKey("audioVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("audioVolume");
            slider.value = PlayerPrefs.GetFloat("audioVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("auidoVolume", 0.5f);
            AudioListener.volume = PlayerPrefs.GetFloat("audioVolume");
            slider.value = PlayerPrefs.GetFloat("audioVolume");
        }
        
    }
}
