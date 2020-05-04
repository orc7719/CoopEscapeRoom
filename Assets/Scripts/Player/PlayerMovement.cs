using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;
    [SerializeField] float sprintSpeed = 5.0f;
    [SerializeField] float maxVelocityChange = 8.0f;

    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float gravity = 9.81f;

    bool isSprinting = false;

    [SerializeField] LayerMask groundLayers;
    private Rigidbody rgdbody;
    private Vector2 inputVector;
    private Vector3 fixedVelocity;
    private Vector3 targetVelocity;
    private Vector3 velocity;

    private void Awake()
    {
        rgdbody = GetComponent<Rigidbody>();
    }

    void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        fixedVelocity = new Vector3(inputVector.x, 0, inputVector.y);
    }

    void OnJump()
    {
        if (IsGrounded())
            rgdbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
    }

    void OnSprint(InputValue value)
    {
        
        isSprinting = value.Get<float>() == 1;
        Debug.Log(isSprinting);
    }

    private void FixedUpdate()
    {
            targetVelocity = transform.TransformDirection(fixedVelocity);
            targetVelocity *= isSprinting? sprintSpeed : speed;

        float maxSpeed = isSprinting ? sprintSpeed : speed;

            velocity = rgdbody.velocity;
            Vector3 velocityChange = targetVelocity - velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxSpeed, maxSpeed);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxSpeed, maxSpeed);
            velocityChange.y = 0.0f;

            rgdbody.AddForce(velocityChange, ForceMode.VelocityChange);
        

        rgdbody.AddForce(new Vector3(0, -gravity * rgdbody.mass, 0));
    }

    bool IsGrounded()
    {
        Ray ray = new Ray(transform.position + (Vector3.up * 0.25f), Vector3.down);
        return Physics.SphereCast(ray, 0.2f, 0.1f, groundLayers);
    }

    float CalculateJumpVerticalSpeed()
    {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}
