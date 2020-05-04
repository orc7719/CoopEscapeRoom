using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float interactDistance = 1.0f;
    [SerializeField] LayerMask interactLayer;
    Interactable currentInteract;

    private void Update()
    {
        RaycastHit hit;

        Debug.DrawLine(cam.transform.position, cam.transform.position + (cam.transform.forward * interactDistance), Color.red);

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactDistance, interactLayer))
        {
            if(hit.transform.GetComponent<Interactable>())
            {
                currentInteract = hit.transform.GetComponentInParent<Interactable>();

                if(currentInteract.isInteractable)
                {

                }
                else
                {

                }
            }
            else
            {
                currentInteract = null;
            }

            Debug.DrawLine(cam.transform.position, hit.point, Color.green);
        }
        else
        {
            currentInteract = null;
        }
    }

    void OnInteract()
    {
        if (currentInteract != null)
        {
            if (currentInteract.isInteractable)
            {
                currentInteract.Interact();
            }
        }
    }
}
