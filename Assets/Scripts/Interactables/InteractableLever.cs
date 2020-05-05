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

    private void Start()
    {
        leverModel = transform.Find("Model");
        leverModel.DOLocalRotateQuaternion(Quaternion.Euler(isActivated ? rotateDistanceMax : rotateDistanceMin, 0, 0), 0);
    }

    public override void Interacted(PlayerInteraction player)
    {
        isActivated = !isActivated;
        StartCoroutine(AnimateLever());
    }

    IEnumerator AnimateLever()
    {
        isInteractable = false;
        leverModel.DOLocalRotateQuaternion(Quaternion.Euler(isActivated ? rotateDistanceMax : rotateDistanceMin, 0, 0), leverCooldown);
        leverEvent.Invoke(isActivated);
        yield return new WaitForSeconds(leverCooldown);
        isInteractable = true;
    }
}
