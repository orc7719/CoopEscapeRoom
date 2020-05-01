using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplayerMenu : MonoBehaviour
{
    CustomNetworkRoomManager manager;
    [SerializeField] RoomPlayerItem[] roomPlayers;

    private void Start()
    {
        manager = CustomNetworkRoomManager.singleton;
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

    public void ShowLobbyUI()
    {

    }

    public void HideLobbyUI()
    {

    }
}
