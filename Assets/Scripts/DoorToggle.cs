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

    [SerializeField] float transitionTime = 2.0f;

    private void Start()
    {
        startPos = doorObject.transform.localPosition;
        startRot = doorObject.transform.localRotation;
    }

    public void MoveDoor(bool newValue)
    {
        doorObject.DOLocalMove(newValue ? targetPos.localPosition : startPos, transitionTime);
        doorObject.DOLocalRotateQuaternion(newValue ? targetPos.localRotation : startRot, transitionTime);
    }
}