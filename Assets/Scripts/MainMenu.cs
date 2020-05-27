using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    [Header("Panels")]
    GameObject activeCanvas;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject backButton;

    [Header("Components")]
    [SerializeField] AudioMixer audioMixer;

    [Header("Settings UI")]
    [SerializeField] TMP_Text mouseText;
    [SerializeField] Slider mouseSlider;
    [SerializeField] TMP_Text fovText;
    [SerializeField] Slider fovSlider;
    [SerializeField] TMP_Text masterText;
    [SerializeField] Slider masterVolSlider;
    [SerializeField] TMP_Text sfxText;
    [SerializeField] Slider sfxVolSlider;
    [SerializeField] TMP_Text ambientText;
    [SerializeField] Slider ambientVolSlider;
    [SerializeField] TMP_Text musicText;
    [SerializeField] Slider musicVolSlider;

    private void OnEnable()
    {
        mouseSlider.onValueChanged.AddListener(UpdateMouseSensitivity);
        fovSlider.onValueChanged.AddListener(UpdateFov);
        masterVolSlider.onValueChanged.AddListener(UpdateMasterVol);
        sfxVolSlider.onValueChanged.AddListener(UpdateSfxVol);
        ambientVolSlider.onValueChanged.AddListener(UpdateAmbientVol);
        musicVolSlider.onValueChanged.AddListener(UpdateMusicVol);
    }

    private void OnDisable()
    {
        mouseSlider.onValueChanged.RemoveListener(UpdateMouseSensitivity);
        fovSlider.onValueChanged.RemoveListener(UpdateFov);
        masterVolSlider.onValueChanged.RemoveListener(UpdateMasterVol);
        sfxVolSlider.onValueChanged.RemoveListener(UpdateSfxVol);
        ambientVolSlider.onValueChanged.RemoveListener(UpdateAmbientVol);
        musicVolSlider.onValueChanged.RemoveListener(UpdateMusicVol);
    }

    private void Start()
    {
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        backButton.SetActive(false);

        LoadSettings();
    }

    public void PlayGame()
    {
        SaveSettings();
        SceneManager.LoadScene(1);
    }

    public void ShowSettings()
    {
        SwitchCanvas(settingsPanel);
    }

    public void ShowCredits()
    {
        SwitchCanvas(creditsPanel);
    }

    public void CloseGame()
    {
        SaveSettings();
        Application.Quit();
    }

    void SwitchCanvas(GameObject newCanvas)
    {
        CloseActiveCanvas();

        newCanvas.SetActive(true);
        activeCanvas = newCanvas;
        backButton.SetActive(true);

        if (newCanvas == settingsPanel)
            LoadSettings();
    }

    public void CloseActiveCanvas()
    {
        if (activeCanvas != null)
        {
            activeCanvas.SetActive(false);
            activeCanvas = null;
            backButton.SetActive(false);
        }
    }

    void LoadSettings()
    {
        audioMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol", 0));
        audioMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SfxVol", 0));
        audioMixer.SetFloat("AmbienceVol", PlayerPrefs.GetFloat("AmbientVol",0));
        audioMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol", 0));
        GameManager.Settings.PlayerData.sensitivity = PlayerPrefs.GetFloat("MouseSens", 1);

        masterVolSlider.value = PlayerPrefs.GetFloat("MasterVol", 0);
        sfxVolSlider.value = PlayerPrefs.GetFloat("SFXVol", 0);
        ambientVolSlider.value = PlayerPrefs.GetFloat("AmbienceVol", 0);
        musicVolSlider.value = PlayerPrefs.GetFloat("MasterVol", 0);
        mouseSlider.value = PlayerPrefs.GetFloat("MusicVol", 1);

        UpdateMasterVol(PlayerPrefs.GetFloat("MasterVol", 0));
        UpdateSfxVol(PlayerPrefs.GetFloat("SFXVol", 0));
        UpdateAmbientVol(PlayerPrefs.GetFloat("AmbienceVol", 0));
        UpdateMusicVol(PlayerPrefs.GetFloat("MusicVol", 0));
        UpdateMouseSensitivity(PlayerPrefs.GetFloat("MouseSens", 1));
    }

    void SaveSettings()
    {
        PlayerPrefs.SetFloat("MasterVol", masterVolSlider.value);
        PlayerPrefs.SetFloat("SfxVol", sfxVolSlider.value);
        PlayerPrefs.SetFloat("AmbientVol", ambientVolSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicVolSlider.value);
        PlayerPrefs.SetFloat("MouseSens", GameManager.Settings.PlayerData.sensitivity);
    }

    void UpdateMouseSensitivity(float newValue)
    {
        GameManager.Settings.PlayerData.sensitivity = newValue;
        mouseText.text = "Mouse Sensitivity: " + newValue.ToString("0.00");
    }

    void UpdateFov(float newValue)
    {

    }

    void UpdateMasterVol(float newValue)
    {
        float stringVal = newValue + 80f;
        masterText.text = "Master Volume: " + stringVal.ToString("00");
        audioMixer.SetFloat("MasterVol", newValue);
    }

    void UpdateSfxVol(float newValue)
    {
        float stringVal = newValue + 80f;
        sfxText.text = "SFX Volume: " + stringVal.ToString("00");
        audioMixer.SetFloat("SFXVol", newValue);
    }

    void UpdateAmbientVol(float newValue)
    {
        float stringVal = newValue + 80f;
        ambientText.text = "Ambient Volume: " + stringVal.ToString("00");
        audioMixer.SetFloat("AmbienceVol", newValue);
    }

    void UpdateMusicVol(float newValue)
    {
        float stringVal = newValue + 80f;
        musicText.text = "Music Volume: " + stringVal.ToString("00");
        audioMixer.SetFloat("MusicVol", newValue);
    }
}
