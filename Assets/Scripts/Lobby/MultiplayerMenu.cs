using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;
using Mirror;
using UnityEngine.SceneManagement;

public class MultiplayerMenu : MonoBehaviour
{
    CustomNetworkRoomManager manager;
    [SerializeField] RoomPlayerItem[] roomPlayers;

    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TMP_Dropdown sceneSelect;
    [SerializeField] TMP_InputField ipInput;
    string currentIp = "127.0.0.1";

    [SerializeField] GameObject menuObjects;
    [SerializeField] GameObject lobbyObjects;
    [SerializeField] GameObject hostObjects;

    [Scene]
    [SerializeField] string menuScene;

    private void Start()
    {
        manager = CustomNetworkRoomManager.singleton;
    }

    private void OnEnable()
    {
        nameInput.onEndEdit.AddListener(UpdateName);
        ipInput.onEndEdit.AddListener(UpdateIp);
        sceneSelect.onValueChanged.AddListener(ChangeStartScene);
    }

    private void OnDisable()
    {
        nameInput.onEndEdit.RemoveListener(UpdateName);
        ipInput.onEndEdit.RemoveListener(UpdateIp);
        sceneSelect.onValueChanged.RemoveListener(ChangeStartScene);
    }

    void UpdateName(string newName)
    {
        GameManager.Settings.PlayerData.playerName = newName;
    }

    void UpdateIp(string newIp)
    {
        currentIp = newIp;
    }

    public void JoinServer()
    {
        lobbyObjects.SetActive(true);
        hostObjects.SetActive(false);
        menuObjects.SetActive(false);

        manager.StartClient();
        manager.networkAddress = currentIp;
    }

    public void HostServer()
    {
        lobbyObjects.SetActive(true);
        hostObjects.SetActive(true);
        menuObjects.SetActive(false);

        manager.StartHost();
    }

    public void LeaveServer()
    {
        lobbyObjects.SetActive(false);
        hostObjects.SetActive(false);
        menuObjects.SetActive(true);

        if (manager.mode == Mirror.NetworkManagerMode.ClientOnly)
        {
            manager.StopClient();
        }
        else if (manager.mode == Mirror.NetworkManagerMode.Host)
        {
            manager.StopHost();
        }
    }

    public void ChangeStartScene(int newScene)
    {
        manager.ChangeStartingScene(newScene);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void ShowLobbyUI()
    {

    }

    public void HideLobbyUI()
    {

    }
}