using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera cam;

    [SerializeField] float ySensitivity = 1.0f;

    [SerializeField] float xSensitivity = 1.0f;
    [SerializeField] float minX = -80.0f;
    [SerializeField] float maxX = 80.0f;

    float xRot;
    Quaternion currentRotation;

    private void Start()
    {
        currentRotation = cam.transform.localRotation;
        UpdateSensitivity();
    }

    public void UpdateSensitivity()
    {
        ySensitivity = GameManager.Settings.PlayerData.sensitivity;
        xSensitivity = GameManager.Settings.PlayerData.sensitivity;
    }

    void OnLookX(InputValue input)
    {
        //Debug.Log("Look X: " + input.Get<float>());
        transform.eulerAngles += new Vector3(0, input.Get<float>() * ySensitivity, 0);
    }

    void OnLookY(InputValue input)
    {
        //Debug.Log("Look Y: " + input.Get<float>());

        xRot += input.Get<float>() * xSensitivity;
        xRot = Mathf.Clamp(xRot, minX, maxX);

        Quaternion xQuaternion = Quaternion.AngleAxis(-xRot, Vector3.right);
        cam.transform.localRotation = currentRotation * xQuaternion;
    }
}