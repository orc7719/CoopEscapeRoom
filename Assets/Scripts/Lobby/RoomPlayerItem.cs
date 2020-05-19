using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RoomPlayerItem : MonoBehaviour
{
    [SerializeField] int playerIndex;

    public static RoomPlayerItem[] roomPlayers = new RoomPlayerItem[2];

    [SerializeField] TMP_Text nameText;
    [SerializeField] Button readyButton;
    [SerializeField] TMP_Text buttonText;
    [SerializeField] GameObject roleButton;
    [SerializeField] TMP_Text roleText;

    bool isReady = false;

    private void Start()
    {
        roomPlayers[playerIndex] = this;
        ResetPlayerItem();
    }

    public void ResetPlayerItem()
    {
        readyButton.interactable = false;
        buttonText.text = "";
        nameText.text = "Waiting for player...";
        roleText.text = "";
        roleButton.SetActive(false);
    }

    public void UpdateRoleButton(bool newValue)
    {
        roleButton.SetActive(newValue);
    }

    public void UpdateReadyButton(bool newStatus)
    {
        readyButton.interactable = newStatus;
    }

    public void UpdateReadyButtonText(bool isLocalPlayer, bool newStatus)
    {
        if(isLocalPlayer)
        {
            buttonText.text = newStatus ? "Cancel" : "Ready";
        }
        else
        {
            buttonText.text = newStatus ? "Ready" : "Not Ready";
        }
    }

    public void ToggleReadyStatus()
    {
        isReady = !isReady;
        CustomNetworkRoomManager.singleton.roomSlots[playerIndex].CmdChangeReadyState(isReady);
    }

    public void UpdatePlayerName(string newName)
    {
        nameText.text = newName;
    }

    public void UpdatePlayerRole(int newRole)
    {
        switch (newRole)
        {
            case 0:
                roleText.text = "Commander";
                break;
            case 1:
                roleText.text = "Survivor";
                break;
            default:
                break;
        }
    }

    public void UpdateStartScene(int newScene)
    {

    }

    public void SwapRoles()
    {
        CustomNetworkRoomManager.singleton.SwapRoles();
    }
}