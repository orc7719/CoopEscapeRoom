using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class doorDoTweenController : MonoBehaviour
{

    [Range(0.5f, 5f), SerializeField] private float _movementDuration = 1.0f;


    private DoTweenType _doTweenType = DoTweenType.openDoor;

    public Vector3 targetRotation;

    private enum DoTweenType {
        openDoor
        
        
    }

    void OnEnable() {
        if (_doTweenType == DoTweenType.openDoor) {
            
            
            //transform.DORotate((targetRotation), _movementDuration, RotateMode.Fast);

            transform.DOMoveY(-10, _movementDuration);
        }
    }
}


