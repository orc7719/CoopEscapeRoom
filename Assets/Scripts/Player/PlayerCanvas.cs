using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : Singleton<PlayerCanvas>
{
    [SerializeField] CanvasGroup interactGroup;
    [SerializeField] CanvasGroup pauseMenuGroup;
    bool menuVisible = false;

    

    public void ShowInteract(bool newValue)
    {
        interactGroup.alpha = newValue ? 1 : 0;
    }


    public void ToggleMenu()
    {
        if (menuVisible)
            HideMenu();
        else
            ShowMenu();
    }

    public void ShowMenu()
    {
        menuVisible = true;

        Player.localPlayer.playerInput.SwitchCurrentActionMap("UI");
        pauseMenuGroup.alpha = menuVisible ? 1 : 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideMenu()
    {
        menuVisible = false;

        Player.localPlayer.playerInput.SwitchCurrentActionMap("Player");
        pauseMenuGroup.alpha = menuVisible ? 1 : 0;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MenuDisconnect()
    {
        CustomNetworkRoomManager.singleton.StopClient();
    }
}