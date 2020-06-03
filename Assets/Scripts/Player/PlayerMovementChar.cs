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

    [Header("Footstep Audio")]
    [SerializeField] float stepDistance = 0.5f;
    [SerializeField] AudioSource footstepSource;
    [SerializeField] AudioClip[] footstepWalkingSounds;
    [SerializeField] AudioClip[] footstepRunningSounds;

    float walkDistance;
    Vector3 lastStepPos;

    [Header("Jump Audio")]
    [SerializeField] AudioClip[] jumpSounds;

    bool isSprinting = false;

    private Vector2 inputVector;
    Vector3 fixedVelocity;
    Vector3 playerVelocity;
    float yVelocity;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        lastStepPos = transform.position;
    }

    void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        fixedVelocity = new Vector3(inputVector.x, 0, inputVector.y);
    }

    void OnJump()
    {
        if (charController.isGrounded)
        {
            yVelocity = jumpHeight;
            footstepSource.PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)]);
        }
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

        if (transform.position.y < -10)
        {
            playerVelocity = Vector3.zero;
            transform.position = PlayerSpawn.instance.transform.position;
            return;
        }



        charController.Move(playerVelocity * Time.deltaTime);

        if (charController.isGrounded)
            if (playerVelocity.x != 0 || playerVelocity.z != 0)
                DoAudio();
    }

    void DoAudio()
    {
        walkDistance += Vector3.Distance(transform.position, lastStepPos);
        lastStepPos = transform.position;

        if (walkDistance >= stepDistance)
        {
            walkDistance = 0;
            AudioClip stepSound;


            if (isSprinting)
                stepSound = footstepRunningSounds[Random.Range(0, footstepRunningSounds.Length)];
            else
                stepSound = footstepWalkingSounds[Random.Range(0, footstepWalkingSounds.Length)];

            footstepSource.PlayOneShot(stepSound);
        }
    }
}