using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using TMPro;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [Header("The Sliders")]
    public Slider masterSlider;
    public Slider SFXSlider;
    public Slider MusicSlider;
    
    [Header("The Value Numbers"), Range(0, 1)]
    public float masterNum;
    [Range(0, 1)]
    public float SFXNum;
    [Range(0, 1)]
    public float MusicNum;

    [Header("Audio Sources")]
    
    public AudioSource SFXSource;
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {

        AudioListener.volume = masterSlider.value;

        SFXSource.volume = SFXSlider.value;

        musicSource.volume = MusicSlider.value;        
    }

    public void changeMaster() {
        masterNum = masterSlider.value;
    }

    public void changeSFX() {
        SFXNum = SFXSlider.value;
    }

    public void changeMusic() {
        MusicNum = MusicSlider.value;
    }
}
