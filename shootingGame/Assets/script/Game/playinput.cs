using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playinput : MonoBehaviour
{
    private PlayerInput playerinput;
    private InputAction movement;
    private Rigidbody rb;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerinput = new PlayerInput();
    }

    private void OnEnable()
    {
        movement = playerinput.Player.Movement;
        movement.Enable();

        playerinput.Player.Jump.performed += DoJump;
        playerinput.Player.Jump.Enable();

    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump");
        
    }

    private void OnDisable()
    {
        movement.Disable();
        playerinput.Player.Jump.Disable();
    }

    private void FixedUpdate()
    {
        Debug.Log("Movement values" + movement.ReadValue<Vector2>());


        
        
    }
}
