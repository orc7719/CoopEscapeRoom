using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class leverDoTweenAnimation : MonoBehaviour
{
    private float movementDuration = 1;

    [SerializeField]GameObject lever, SelectedDoor;

    Quaternion targetRotation;

    void Start() {
        
    }

    public void LeverActivated() {

        SelectedDoor.GetComponent<doorDoTweenController>().enabled = true;

    }
}
