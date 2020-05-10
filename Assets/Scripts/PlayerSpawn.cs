using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Start()
    {
        Player playerObject = Player.localPlayer;

        playerObject.transform.position = transform.position;
        playerObject.transform.rotation = transform.rotation;

        playerObject.EnablePlayer();
    }
}