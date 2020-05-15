using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorToggle : MonoBehaviour
{
    [SerializeField] Transform doorObject;

    [SerializeField] Transform targetPos;
    Vector3 startPos;
    Quaternion startRot;

    [SerializeField] bool doorStatus;

    [SerializeField] float transitionTime = 2.0f;

    private void Start()
    {
        startPos = doorObject.transform.localPosition;
        startRot = doorObject.transform.localRotation;

        MoveDoor(doorStatus, 0);
    }

    public void ToggleDoor()
    {
        MoveDoor(!doorStatus);
    }

    public void MoveDoor(bool newValue)
    {
        MoveDoor(newValue, 1f);
    }

    public void MoveDoor(bool newValue, float modifier)
    {
        doorStatus = newValue;
        doorObject.DOLocalMove(newValue ? targetPos.localPosition : startPos, transitionTime * modifier);
        doorObject.DOLocalRotateQuaternion(newValue ? targetPos.localRotation : startRot, transitionTime * modifier);
    }
}