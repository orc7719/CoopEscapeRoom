using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrabbableObject : Interactable
{
    Transform attachPoint;
    bool wasDropped = false;
    Vector3 startPos;
    Quaternion startRot;
    Rigidbody rgdbody;
    Collider[] colliders;


    private void Start()
    {
        colliders = GetComponentsInChildren<Collider>();
        rgdbody = GetComponent<Rigidbody>();
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
        //Disable physics
        rgdbody.velocity = Vector3.zero;
        rgdbody.isKinematic = true;
        rgdbody.useGravity = false;

        //Attach to player
        ToggleAllColliders(false);
        transform.parent = player.holdPoint;
        transform.localPosition = attachPoint.localPosition;

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
        rgdbody.isKinematic = false;
        rgdbody.useGravity = true;
        ToggleAllColliders(true);

        rgdbody.velocity = Vector3.zero;
        transform.position = startPos;
        transform.rotation = startRot;
    }
}
