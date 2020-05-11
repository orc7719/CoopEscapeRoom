using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [Header("Audio Mixer")]
    public AudioMixer Master;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
              
    }

        public void adjustMasterVolume(float soundLevel) {
        Master.SetFloat("MasterVol", soundLevel);
       
    }

        public void adjustSFXVolume(float soundLevel) {
        Master.SetFloat("SFXVol", soundLevel);
    }

        public void adjustMusicVolume(float soundLevel) {
        Master.SetFloat("MusicVol", soundLevel);
    }

    public void adjustAmbienceVolume(float soundLevel) {
        Master.SetFloat("AmbienceVol", soundLevel);
    }
    
}
