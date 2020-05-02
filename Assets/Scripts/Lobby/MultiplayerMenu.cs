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

    private void Start()
    {
        manager = CustomNetworkRoomManager.singleton;
    }

    private void OnEnable()
    {
        nameInput.onEndEdit.AddListener(UpdateName);
    }

    private void OnDisable()
    {
        nameInput.onEndEdit.RemoveListener(UpdateName);
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

    public void ShowLobbyUI()
    {

    }

    public void HideLobbyUI()
    {

    }
}
