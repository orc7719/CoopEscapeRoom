using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Managers/Game Settings")]
public class GameSettings : ScriptableSingleton<GameSettings>
{
    [Serializable]
    public class PlayerInfo
    {
        public string playerName = "Player";
    }

    [SerializeField]
    private PlayerInfo _playerData = new PlayerInfo();
    public PlayerInfo PlayerData { get { return _playerData; } }
}