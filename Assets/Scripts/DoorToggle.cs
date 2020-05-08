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
        startPos = doorObject.transform.position;
        startRot = doorObject.transform.rotation;
    }

    public void MoveDoor(bool newValue)
    {
        doorObject.DOMove(newValue ? targetPos.position : startPos, transitionTime);
        doorObject.DORotateQuaternion(newValue ? targetPos.rotation : startRot, transitionTime);
    }
}
