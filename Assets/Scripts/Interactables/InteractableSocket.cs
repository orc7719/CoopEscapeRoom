using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SocketTypes { Generic, Fuse }
public enum SocketTags { None, Red, Green, Blue}

public class InteractableSocket : Interactable
{
    [Header("Socket Settings")]
    [SerializeField] SocketTypes socketType = SocketTypes.Generic;
    [SerializeField] SocketTags correctTag = SocketTags.None;

    [Header("Output Events")]
    [SerializeField] ToggleEvent OnSocketUpdated;
    public bool socketCorrect = false;
    
    public SocketableObject socketedObject= null;

    public override void Interacted(PlayerInteraction player)
    {
        if (socketedObject == null)
        {
            SocketableObject targetObject = player.heldObject as SocketableObject;

            if (targetObject != null)
            {
                if (targetObject.socketType == socketType)
                    targetObject.AttachToSocket(player, this);

                if (socketedObject.socketTag == correctTag)
                {
                    socketCorrect = true;
                    if (OnSocketUpdated != null)
                        OnSocketUpdated.Invoke(true);
                }
                else
                {
                    socketCorrect = false;
                }
            }
        }
        else
        {
            socketedObject.AttachToPlayer(player);
            socketedObject = null;

            socketCorrect = false;
            if (OnSocketUpdated != null)
                OnSocketUpdated.Invoke(false);
        }
    }
}
