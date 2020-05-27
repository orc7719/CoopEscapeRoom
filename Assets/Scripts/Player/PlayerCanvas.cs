using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;
using UnityEngine.Audio;

public class PlayerCanvas : Singleton<PlayerCanvas>
{
    [SerializeField] CanvasGroup interactGroup;
    [SerializeField] CanvasGroup pauseMenuGroup;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject settingsPanel;
    bool menuVisible = false;
    [Scene]
    string MenuScene;

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

    protected override void Start()
    {
        base.Start();
        ToggleMenu();
    }

    public void ShowInteract(bool newValue)
    {
        interactGroup.alpha = newValue ? 1 : 0;
    }

    public void ShowSettings()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        LoadSettings();
    }

    public void HideSettings()
    {
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        SaveSettings();
        UpdateSettings();
    }

    public void UpdateSettings()
    {
        if (Player.localPlayer)
            Player.localPlayer.GetComponent<CameraController>().UpdateSensitivity();
    }

    public void ToggleMenu()
    {
        if (menuVisible)
            HideMenu();
        else
            ShowMenu();
    }

    public void ShowMenu()
    {
        if (Player.localPlayer != null)
        {
            menuVisible = true;

            Player.localPlayer.playerInput.SwitchCurrentActionMap("UI");
            pauseMenuGroup.alpha = menuVisible ? 1 : 0;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void HideMenu()
    {
        if (Player.localPlayer != null)
        {
            menuVisible = false;

            Player.localPlayer.playerInput.SwitchCurrentActionMap("Player");
            pauseMenuGroup.alpha = menuVisible ? 1 : 0;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            UpdateSettings();
            HideSettings();
        }
    }

    public void MenuDisconnect()
    {
        HideMenu();

        CustomNetworkRoomManager.singleton.StopClient();
        SceneLoader.Instance.ReturnToMenu();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

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
    void LoadSettings()
    {
        audioMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol", 0));
        audioMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SfxVol", 0));
        audioMixer.SetFloat("AmbienceVol", PlayerPrefs.GetFloat("AmbientVol", 0));
        audioMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol", 0));
        GameManager.Settings.PlayerData.sensitivity = PlayerPrefs.GetFloat("MouseSens", 1);

        masterVolSlider.value = PlayerPrefs.GetFloat("MasterVol", 0);
        sfxVolSlider.value = PlayerPrefs.GetFloat("SFXVol", 0);
        ambientVolSlider.value = PlayerPrefs.GetFloat("AmbienceVol", 0);
        musicVolSlider.value = PlayerPrefs.GetFloat("MusicVol", 0);
        mouseSlider.value = PlayerPrefs.GetFloat("MouseSens", 1);

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
        float stringVal = newValue +80f;
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