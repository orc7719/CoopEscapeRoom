using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{

    [SerializeField] float xSensitivity = 5.0f;

    [SerializeField] float maxX = 80f;
    [SerializeField] float minX = -80f;

    float xRot;
    Quaternion currentRotation;

    private void Start()
    {
        currentRotation = transform.localRotation;
    }

    void Update()
    {
        xRot += Input.GetAxis("Mouse Y") * xSensitivity;
        xRot = Mathf.Clamp(xRot, minX, maxX);

        Quaternion xQuaternion = Quaternion.AngleAxis(-xRot, Vector3.right);
        transform.localRotation = currentRotation * xQuaternion;
    }
}
