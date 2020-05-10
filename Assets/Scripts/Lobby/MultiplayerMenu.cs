using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;

public class MultiplayerMenu : MonoBehaviour
{
    CustomNetworkRoomManager manager;
    [SerializeField] RoomPlayerItem[] roomPlayers;

    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TMP_Dropdown sceneSelect;
    

    private void Start()
    {
        manager = CustomNetworkRoomManager.singleton;
    }

    private void OnEnable()
    {
        nameInput.onEndEdit.AddListener(UpdateName);
        sceneSelect.onValueChanged.AddListener(ChangeStartScene);
    }

    private void OnDisable()
    {
        nameInput.onEndEdit.RemoveListener(UpdateName);
        sceneSelect.onValueChanged.RemoveListener(ChangeStartScene);
    }

    void UpdateName(string newName)
    {
        GameManager.Settings.PlayerData.playerName = newName;
    }

    public void JoinServer()
    {
        manager.StartClient();
        manager.networkAddress = "localhost";
    }

    public void HostServer()
    {
        manager.StartHost();
    }

    public void LeaveServer()
    {
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

    public void ShowLobbyUI()
    {

    }

    public void HideLobbyUI()
    {

    }
}
