using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkRoomManager : NetworkRoomManager
{
    public static new CustomNetworkRoomManager singleton { get { return NetworkManager.singleton as CustomNetworkRoomManager; } }
}
