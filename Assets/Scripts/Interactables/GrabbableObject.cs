using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrabbableObject : Interactable
{
    Transform attachPoint;
    public bool wasDropped = false;
    Vector3 startPos;
    Quaternion startRot;
    Collider[] colliders;

    private void Start()
    {
        colliders = GetComponentsInChildren<Collider>();
        attachPoint = transform.Find("AttachPoint");
        startPos = transform.position;
        startRot = transform.rotation;
    }

    public override void Interacted(PlayerInteraction player)
    {
            player.PickupObject(this);
    }

    public void AttachToPlayer(PlayerInteraction player)
    {
        if (player.heldObject == null)
        {
            //Attach to player
            player.heldObject = this;
            ToggleAllColliders(false);
            transform.parent = player.holdPoint;

            transform.DOLocalMove(-attachPoint.localPosition, 0.25f);
            transform.DOLocalRotateQuaternion(attachPoint.localRotation, 0.25f);

            wasDropped = false;
        }
    }

    public void ToggleAllColliders(bool newValue)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = newValue;
        }
    }

    public void Drop(PlayerInteraction player)
    {
        player.heldObject = null;

        wasDropped = true;
        transform.parent = null;
        ToggleAllColliders(true);

        transform.position = startPos;
        transform.rotation = startRot;
    }
}