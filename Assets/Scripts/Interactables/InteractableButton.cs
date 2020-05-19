using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractableButton : Interactable
{
    Transform buttonModel;
    [SerializeField] float pressDistance = 0.05f;
    [SerializeField] float buttonCooldown = 0.8f;

    AudioSource audioSource;
    [SerializeField] AudioClip pressedSound;

    private void Start()
    {
        buttonModel = transform.Find("Model");
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interacted(PlayerInteraction player)
    {
        StartCoroutine(AnimateButton());
    }

    IEnumerator AnimateButton()
    {
        audioSource.PlayOneShot(pressedSound);
        isInteractable = InteractState.Cooldown;
        buttonModel.DOLocalMoveY(-pressDistance, buttonCooldown / 2);
        yield return new WaitForSeconds(buttonCooldown / 2);
        buttonModel.DOLocalMoveY(0, buttonCooldown / 2);
        isInteractable = InteractState.Interactable;
    }
}