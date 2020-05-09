using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkRoomManager : NetworkRoomManager
{
    public static new CustomNetworkRoomManager singleton { get { return NetworkManager.singleton as CustomNetworkRoomManager; } }

    // for users to apply settings from their room player object to their in-game player object
    /// <summary>
    /// This is called on the server when it is told that a client has finished switching from the room scene to a game player scene.
    /// <para>When switching from the room, the room-player is replaced with a game-player object. This callback function gives an opportunity to apply state from the room-player to the game-player object.</para>
    /// </summary>
    /// <param name="conn">The connection of the player</param>
    /// <param name="roomPlayer">The room player object.</param>
    /// <param name="gamePlayer">The game player object.</param>
    /// <returns>False to not allow this player to replace the room player.</returns>
    public override bool OnRoomServerSceneLoadedForPlayer(NetworkConnection conn, GameObject roomPlayer, GameObject gamePlayer)
    {
        CustomNetworkRoomPlayer roomPlayerScript = roomPlayer.GetComponent<CustomNetworkRoomPlayer>();
        Player scenePlayerScript = gamePlayer.GetComponent<Player>();

        scenePlayerScript.SetRoleId(roomPlayerScript.roleId);

        return true;
    }

    public void SwapRoles()
    {
        if (roomSlots.Count == 2)
        {
            CustomNetworkRoomPlayer player01 = (CustomNetworkRoomPlayer)roomSlots[0];
            CustomNetworkRoomPlayer player02 = (CustomNetworkRoomPlayer)roomSlots[1];

            int tempRole = player01.roleId;

            player01.roleId = player02.roleId;
            player02.roleId = tempRole;
        }
    }
}
