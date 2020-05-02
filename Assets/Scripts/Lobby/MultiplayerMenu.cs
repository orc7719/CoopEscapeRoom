using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        
    }

    private void OnDisable()
    {
        
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
