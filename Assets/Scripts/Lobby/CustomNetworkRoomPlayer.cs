using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkRoomPlayer : NetworkRoomPlayer
{
    [Header("Player Info")]
    [SyncVar] public string playerName = "";


    // This is a hook that is invoked on all player objects when entering the room.
    // Note: isLocalPlayer is not guaranteed to be set until OnStartLocalPlayer is called.
    public override void OnClientEnterRoom()
    {
        RoomPlayerItem.roomPlayers[index].UpdateReadyButton(isLocalPlayer);
        RoomPlayerItem.roomPlayers[index].UpdateReadyButtonText(isLocalPlayer, false);
    }

    // This is a hook that is invoked on all player objects when exiting the room.
    public override void OnClientExitRoom()
    {
       
    }

    // This is a hook that is invoked on clients when a RoomPlayer switches between ready or not ready.
    // This function is called when the a client player calls CmdChangeReadyState.
    public override void OnClientReady(bool readyState)
    {
        RoomPlayerItem.roomPlayers[index].UpdateReadyButtonText(isLocalPlayer, readyState);
    }
}