using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider effectsSlider;
    public float masterDefaultValue, musicDefaultValue, effectDefaultValue;

    void Start() 
    {
        //set default value 
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", masterDefaultValue);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", musicDefaultValue);
        effectsSlider.value = PlayerPrefs.GetFloat("AffectVolume", effectDefaultValue);
    }

    public void SetMasterLevel(float sliderValue)
    {
        mixer.SetFloat ("MasterVol", Mathf.Log10 (sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVolume",sliderValue);
    }

    public void SetMusicLevel(float sliderValue)
    {
        mixer.SetFloat ("MusicVol", Mathf.Log10 (sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume",sliderValue);
    }

    public void SetEffectLevel(float sliderValue)
    {
        mixer.SetFloat ("EffectVol", Mathf.Log10 (sliderValue) * 20);
        PlayerPrefs.SetFloat("AffectVolume",sliderValue);
    }

}
