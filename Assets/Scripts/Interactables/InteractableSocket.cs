using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SocketTypes { Generic, Fuse }

public class InteractableSocket : Interactable
{
    
    [SerializeField] SocketTypes socketType = SocketTypes.Generic;
    public SocketableObject socketedObject= null;

    public override void Interacted(PlayerInteraction player)
    {
        if (socketedObject == null)
        {
            SocketableObject targetObject = player.heldObject as SocketableObject;

            if (targetObject != null)
            {
                targetObject.AttachToSocket(player,this);
            }
        }
        else
        {
            socketedObject.AttachToPlayer(player);
            socketedObject = null;
        }
    }
}
