using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using DG.Tweening;

public class InteractableSceneDoor : Interactable
{
    [Scene]
    [SerializeField] string nextScene;
    [SerializeField] float doorTime = 0.5f;
    [SerializeField] Transform doorTarget;
    Transform model;


    private void Start()
    {
        model = transform.Find("Model");
    }

    public override InteractState IsInteractable(PlayerInteraction player)
    {
        return isInteractable;
    }

    public override void Interacted(PlayerInteraction player)
    {
        StartCoroutine("ChangeSceneAnim");
    }

    IEnumerator ChangeSceneAnim()
    {
        isInteractable = InteractState.Cooldown;

        model.DOLocalMove(doorTarget.localPosition, doorTime);
        model.DOLocalRotateQuaternion(doorTarget.localRotation, doorTime);

        yield return new WaitForSeconds(doorTime);

        SceneLoader.Instance.LoadGameScene(nextScene);
    }
}
