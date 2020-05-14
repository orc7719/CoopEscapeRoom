using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSceneChanger : Interactable
{
    [Scene]
    [SerializeField] string nextScene;

    public override void Interacted(PlayerInteraction player)
    {
        SceneLoader.Instance.LoadGameScene(nextScene);
    }
}
