using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementChar : MonoBehaviour
{
    CharacterController charController;

    [SerializeField] float speed = 10.0f;
    [SerializeField] float sprintMulti = 1.5f;

    [SerializeField] float jumpHeight = 3.0f;
    [SerializeField] float gravity = 9.81f;

    bool isSprinting = false;

    private Vector2 inputVector;
    Vector3 fixedVelocity;
    Vector3 playerVelocity;
    float yVelocity;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        fixedVelocity = new Vector3(inputVector.x, 0, inputVector.y);
    }

    void OnJump()
    {
        if (charController.isGrounded)
            yVelocity = jumpHeight;
    }

    void OnSprint(InputValue value)
    {

        isSprinting = value.Get<float>() == 1;
        Debug.Log(isSprinting);
    }

    private void Update()
    {
        playerVelocity = transform.TransformDirection(fixedVelocity);
        playerVelocity *= speed;

        if (isSprinting)
            playerVelocity *= sprintMulti;

        if (!charController.isGrounded)
            yVelocity -= gravity * Time.deltaTime;

        playerVelocity.y = yVelocity;
        charController.Move(playerVelocity * Time.deltaTime);
    }
}