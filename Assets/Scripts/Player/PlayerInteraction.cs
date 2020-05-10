using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float interactDistance = 1.0f;
    [SerializeField] LayerMask interactLayer;
    Interactable currentInteract;

    public Transform holdPoint;
    public GrabbableObject heldObject;

    private void Update()
    {
        RaycastHit hit;

        Debug.DrawLine(cam.transform.position, cam.transform.position + (cam.transform.forward * interactDistance), Color.red);

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactDistance, interactLayer))
        {
            if(hit.transform.GetComponent<Interactable>())
            {
                currentInteract = hit.transform.GetComponent<Interactable>();

                if(currentInteract.IsInteractable(this) == Interactable.InteractState.Interactable || currentInteract.IsInteractable(this) == Interactable.InteractState.Cooldown)
                {
                    PlayerCanvas.Instance.ShowInteract(true);
                }
                else
                {

                }
            }
            else
            {
                currentInteract = null;
                PlayerCanvas.Instance.ShowInteract(false);
            }

            Debug.DrawLine(cam.transform.position, hit.point, Color.green);
        }
        else
        {
            currentInteract = null;
            PlayerCanvas.Instance.ShowInteract(false);
        }
    }

    void OnInteract()
    {
        if (currentInteract != null)
        {
            if (currentInteract.IsInteractable(this) == Interactable.InteractState.Interactable)
            {
                currentInteract.Interact(this);
            }
        }
    }

    void OnDrop()
    {
        if (heldObject)
        {
            heldObject.Drop(this);
        }
    }

    public void PickupObject(GrabbableObject newObject)
    {
        if (heldObject)
            heldObject.Drop(this);

        newObject.AttachToPlayer(this);
    }

    public void DropObject()
    {
        heldObject = null;
    }
}