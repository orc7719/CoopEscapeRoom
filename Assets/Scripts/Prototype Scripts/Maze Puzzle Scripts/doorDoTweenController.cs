using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class doorDoTweenController : MonoBehaviour
{

    [Range(0.5f, 5f), SerializeField] private float _movementDuration = 1.0f;


    private DoTweenType _doTweenType = DoTweenType.openDoor;

    private enum DoTweenType {
        openDoor
        
        
    }

    void OnEnable() {
        if (_doTweenType == DoTweenType.openDoor) {
            
            
            transform.DORotate(new Vector3(0, 0, 0), _movementDuration, RotateMode.Fast);
        }
    }
}


