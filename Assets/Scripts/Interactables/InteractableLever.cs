using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractableLever : Interactable
{
    Transform leverModel;
    [SerializeField] float rotateDistanceMax = 40.0f;
    [SerializeField] float rotateDistanceMin = -40.0f;
    [SerializeField] float leverCooldown = 0.4f;

    [SerializeField] ToggleEvent leverEvent;

    bool isActivated = false;

    [SerializeField] AudioClip interactSound;
    AudioSource audioSource;

    private void Start()
    {
        leverModel = transform.Find("Model");
        leverModel.DOLocalRotateQuaternion(Quaternion.Euler(isActivated ? rotateDistanceMin : rotateDistanceMax, 0, 0), 0);
        leverEvent.Invoke(isActivated);
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interacted(PlayerInteraction player)
    {
        isActivated = !isActivated;
        StartCoroutine(AnimateLever());
    }

    IEnumerator AnimateLever()
    {
        if (interactSound != null)
            audioSource.PlayOneShot(interactSound);


        isInteractable = InteractState.Cooldown;
        leverModel.DOLocalRotateQuaternion(Quaternion.Euler(isActivated ? rotateDistanceMin : rotateDistanceMax, 0, 0), leverCooldown);
        leverEvent.Invoke(isActivated);
        yield return new WaitForSeconds(leverCooldown);
        isInteractable = InteractState.Interactable;
    }
}