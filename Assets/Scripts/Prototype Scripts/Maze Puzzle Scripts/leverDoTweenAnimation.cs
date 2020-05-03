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
        lever = GameObject.Find("lever");

        lever.transform.DORotateQuaternion(Quaternion.EulerAngles(0, -90, -90), movementDuration);

        SelectedDoor.GetComponent<doorDoTweenController>().enabled = true;

        //lever.transform.DOMove(new Vector3(0.539f, 0.000865f, -0.2644743f), movementDuration);
    }
}
