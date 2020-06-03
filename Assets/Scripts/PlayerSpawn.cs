using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public static PlayerSpawn instance;

    private void Start()
    {
        instance = this;

        Player playerObject = Player.localPlayer;

        if (playerObject)
        {
            playerObject.transform.position = transform.position;
            playerObject.transform.rotation = transform.rotation;

            playerObject.EnablePlayer();
        }
    }
}