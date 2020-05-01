using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent OnInteract;

    public bool isInteractable = true;
    public void Interact()
    {
        OnInteract.Invoke();

        Debug.Log(gameObject.name + " Interacted With");

        Interacted();
    }

    public virtual void Interacted()
    {

    }
}