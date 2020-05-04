using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : Singleton<PlayerCanvas>
{
    [SerializeField] CanvasGroup interactGroup;

    public void ShowInteract(bool newValue)
    {
        interactGroup.alpha = newValue ? 1 : 0;
    }
}
