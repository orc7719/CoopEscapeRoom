using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent OnInteract;

    public enum InteractState { None, Locked, Interactable, Cooldown}
    public InteractState isInteractable = InteractState.Interactable;

    public virtual InteractState IsInteractable(PlayerInteraction player)
    {
        return isInteractable;
    }

    public void Interact(PlayerInteraction player)
    {
        OnInteract.Invoke();
        Interacted(player);
    }

    public virtual void Interacted(PlayerInteraction player) { }
}