using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewInputWSAD : MonoBehaviour
{

    //Input Actions
    SinglePlayerFPS playerInput;

    //Move
    Vector2 movementInput;


void Awake() {
    playerInput = new SinglePlayerFPS();

    playerInput.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();

}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        float h = movementInput.x;
        float v = movementInput.y;
    }

    void OnEnable() {
        playerInput.Enable();
    }

    void OnDisable() {
        playerInput.Disable();
    }
}
