using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent OnInteract;

    public bool isInteractable = true;
    public void Interact(PlayerInteraction player)
    {
        OnInteract.Invoke();
        Interacted(player);
    }

    public virtual void Interacted(PlayerInteraction player) { }
}