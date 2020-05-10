using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusebox : MonoBehaviour
{
    [SerializeField] List<InteractableSocket> fuseSockets = new List<InteractableSocket>();

    private void OnEnable()
    {
        for (int i = 0; i < fuseSockets.Count; i++)
        {
            fuseSockets[i].OnSocketUpdated.AddListener(CheckFuseboxStatus);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < fuseSockets.Count; i++)
        {
            fuseSockets[i].OnSocketUpdated.RemoveListener(CheckFuseboxStatus);
        }
    }

    public void CheckFuseboxStatus(bool newValue)
    {
        bool fusesCorrect = true;

        for (int i = 0; i < fuseSockets.Count; i++)
        {
            if (!fuseSockets[i].socketCorrect)
            {
                fusesCorrect = false;
                break;
            }
        }
    }
}