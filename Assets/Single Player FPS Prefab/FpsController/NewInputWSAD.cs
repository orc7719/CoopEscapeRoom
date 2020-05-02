using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class NewInputWSAD : MonoBehaviour
{

    //Input Actions
    SinglePlayerFPS playerInput;

    //Move
    Vector2 movementInput;

    Vector2 lookRotation;

    Rigidbody player;

    public float verticalSpeed, horizontalSpeed;


void Awake() {
    playerInput = new SinglePlayerFPS();

    playerInput.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();


    
}

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float h = movementInput.x;
        float v = movementInput.y;

        if (h > 0) {
            player.AddForce(transform.right * verticalSpeed);
        }
        else if (h < 0) {
            player.AddForce(transform.right * -verticalSpeed);
        }

        if (v > 0) {
            player.AddForce(transform.forward * horizontalSpeed);
        }
        else if (v < 0) {
            player.AddForce(transform.forward * -horizontalSpeed);
        }

      

    }

    void OnEnable() {
        playerInput.Enable();
    }

    void OnDisable() {
        playerInput.Disable();
    }

    
}
