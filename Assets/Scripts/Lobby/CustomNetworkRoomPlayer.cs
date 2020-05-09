using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkRoomPlayer : NetworkRoomPlayer
{
    [Header("Player Info")]
    [SyncVar(hook = nameof(SetName))] public string playerName = "";
    [SyncVar(hook = nameof(SetRole))] public int roleId = -1;


    // This is a hook that is invoked on all player objects when entering the room.
    // Note: isLocalPlayer is not guaranteed to be set until OnStartLocalPlayer is called.
    public override void OnClientEnterRoom()
    {
        RoomPlayerItem.roomPlayers[index].UpdateReadyButton(isLocalPlayer);
        RoomPlayerItem.roomPlayers[index].UpdateReadyButtonText(isLocalPlayer, false);

        if (isServer)
            UpdatePlayerRole(index);

        RoomPlayerItem.roomPlayers[index].UpdateRoleButton(isServer && isLocalPlayer);
    }

    /// Called when the local player object has been set up.
    /// This happens after OnStartClient(), as it is triggered by an ownership message from the server. This is an appropriate place to activate components or functionality that should only be active for the local player, such as cameras and input.
    public override void OnStartLocalPlayer()
    {
        if (isLocalPlayer)
        {
            CmdUpdatePlayerName(GameManager.Settings.PlayerData.playerName);
            
        }
    }

    private void OnDestroy()
    {
        if (CustomNetworkRoomManager.IsSceneActive(CustomNetworkRoomManager.singleton.RoomScene))
            RoomPlayerItem.roomPlayers[index].ResetPlayerItem();
    }

    // This is a hook that is invoked on clients when a RoomPlayer switches between ready or not ready.
    // This function is called when the a client player calls CmdChangeReadyState.
    public override void OnClientReady(bool readyState)
    {
        RoomPlayerItem.roomPlayers[index].UpdateReadyButtonText(isLocalPlayer, readyState);
    }


    [Command]
    void CmdUpdatePlayerName(string newName)
    {
        playerName = newName;
    }

    private void SetName(string oldName, string newName)
    {
        RoomPlayerItem.roomPlayers[index].UpdatePlayerName(newName);
    }

    
    void UpdatePlayerRole(int newRole)
    {
        roleId = newRole;
    }

    private void SetRole(int oldRole, int newRole)
    {
        RoomPlayerItem.roomPlayers[index].UpdatePlayerRole(newRole);
    }
}