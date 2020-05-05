using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : Interactable
{
    Transform attachPoint;
    bool wasDropped = false;
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
        //Attach to player
        ToggleAllColliders(false);
        transform.parent = player.holdPoint;
        transform.localPosition = -attachPoint.localPosition;
        transform.localRotation = attachPoint.localRotation;

        wasDropped = false;
    }


    void ToggleAllColliders(bool newValue)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = newValue;
        }
    }

    public void Drop()
    {
        wasDropped = true;
        transform.parent = null;
        ToggleAllColliders(true);

        transform.position = startPos;
        transform.rotation = startRot;
    }
}
