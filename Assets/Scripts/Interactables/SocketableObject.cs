using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SocketableObject : GrabbableObject
{
    public SocketTypes socketType = SocketTypes.Generic;
    public SocketTags socketTag = SocketTags.None;
    bool isSocketed = false;

    public override InteractState IsInteractable(PlayerInteraction player)
    {
        return isSocketed ? InteractState.None : isInteractable;
    }

    public void AttachToSocket(PlayerInteraction player, InteractableSocket socket)
    {
        player.DropObject();
        socket.socketedObject = this;

        //Attach to player
        ToggleAllColliders(false);
        transform.parent = socket.transform;

        transform.DOMove(socket.transform.position, 0.25f);
        transform.DORotateQuaternion(socket.transform.rotation, 0.25f);

        isSocketed = true;
        wasDropped = false;
    }

    public void DetachFromSocket(PlayerInteraction player)
    {
        AttachToPlayer(player);
        isSocketed = false;
    }
}