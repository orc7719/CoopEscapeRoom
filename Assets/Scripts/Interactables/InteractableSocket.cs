using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SocketTypes { Generic, Fuse }
public enum SocketTags { None, Red, Green, Blue, Yellow, Orange, Purple, Cyan, Pink }

public class InteractableSocket : Interactable
{
    [Header("Socket Settings")]
    [SerializeField] SocketTypes socketType = SocketTypes.Generic;
    [SerializeField] SocketTags correctTag = SocketTags.None;

    [Header("Output Events")]
    public ToggleEvent OnSocketUpdated;
    public bool socketCorrect = false;
    
    public SocketableObject socketedObject= null;
    [SerializeField] Transform objectHighlight;

    private void Start()
    {
        objectHighlight = transform.Find("Highlight");
    }

    public override InteractState IsInteractable(PlayerInteraction player)
    {
        if (player.heldObject == null && socketedObject == null)
            return InteractState.Locked;

        if (player.heldObject == null && socketedObject != null)
            return isInteractable;

        SocketableObject targetObject = player.heldObject as SocketableObject;
        if (targetObject != null)
        {
            if (targetObject.socketType == socketType)
                return InteractState.Interactable;
            else
                return InteractState.Locked;
        }
        return InteractState.None;
    }

    public override void Interacted(PlayerInteraction player)
    {
        if (socketedObject == null)
        {
            SocketableObject targetObject = player.heldObject as SocketableObject;

            if (targetObject != null)
            {
                if (targetObject.socketType == socketType)
                {
                    targetObject.AttachToSocket(player, this);

                    if (socketedObject.socketTag == correctTag)
                    {
                        socketCorrect = true;
                    }
                    else
                    {
                        socketCorrect = false;
                    }

                    if (OnSocketUpdated != null)
                        OnSocketUpdated.Invoke(socketCorrect);

                    objectHighlight.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            socketedObject.DetachFromSocket(player);
            socketedObject = null;

            socketCorrect = false;
            if (OnSocketUpdated != null)
                OnSocketUpdated.Invoke(false);

            objectHighlight.gameObject.SetActive(true);
        }
    }
}