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

    AudioSource audioSource;
    [SerializeField] AudioClip openSound;

    private void Start()
    {
        model = transform.Find("Model");
        audioSource = GetComponent<AudioSource>();
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
        if (openSound != null)
            audioSource.PlayOneShot(openSound);

        isInteractable = InteractState.Cooldown;

        model.DOLocalMove(doorTarget.localPosition, doorTime);
        model.DOLocalRotateQuaternion(doorTarget.localRotation, doorTime);

        yield return new WaitForSeconds(doorTime);

        SceneLoader.Instance.LoadGameScene(nextScene);
    }
}
