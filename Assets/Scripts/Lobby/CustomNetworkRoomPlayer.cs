using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkRoomPlayer : NetworkRoomPlayer
{
    [Header("Player Info")]
    [SyncVar(hook = nameof(SetName))] public string playerName = "";


    // This is a hook that is invoked on all player objects when entering the room.
    // Note: isLocalPlayer is not guaranteed to be set until OnStartLocalPlayer is called.
    public override void OnClientEnterRoom()
    {
        RoomPlayerItem.roomPlayers[index].UpdateReadyButton(isLocalPlayer);
        RoomPlayerItem.roomPlayers[index].UpdateReadyButtonText(isLocalPlayer, false);


    }

    /// Called when the local player object has been set up.
    /// This happens after OnStartClient(), as it is triggered by an ownership message from the server. This is an appropriate place to activate components or functionality that should only be active for the local player, such as cameras and input.
    public override void OnStartLocalPlayer()
    {
        string newPlayerName = Random.Range(0, 10000).ToString("000000");

            RoomPlayerItem.roomPlayers[index].UpdatePlayerName(newPlayerName);

        if (isLocalPlayer)
            CmdUpdatePlayerName(newPlayerName);
    }

    // This is a hook that is invoked on all player objects when exiting the room.
    public override void OnClientExitRoom()
    {

    }

    private void OnDestroy()
    {
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
}