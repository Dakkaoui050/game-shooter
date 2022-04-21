using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playinput : MonoBehaviour
{
    Animator animator;
    private PlayerInput playerinput;
    private PlayerInput.PlayerActions player;
    private Vector2 Movement;
    private InputAction movement;
    

    public playermotot motot;
    public PlayerLook look;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        playerinput = new PlayerInput();
        player = playerinput.Player;
        motot = GetComponent<playermotot>();
        look = GetComponent<PlayerLook>();
        player.Jump.performed += ctx => motot.Jump();
        player.Run.performed += ctx => motot.Running();
        player.Crouch.performed += ctx => motot.Crouching();

        player.Run.performed += ctx => animator.SetBool("isRunning", true);
        player.Run.canceled += ctx => animator.SetBool("isRunning", false);
       
        player.Movement.performed += ctx => animator.SetBool("isWalking", true);
        player.Movement.canceled += ctx => animator.SetBool("isWalking", false);

        player.Crouch.performed += ctx => animator.SetBool("isCrouching", true);
        player.Crouch.canceled += ctx => animator.SetBool("isCrouching", false);
    }

    private void FixedUpdate()
    {
        motot.ProcessMove(player.Movement.ReadValue<Vector2>()); 
        


    }
    private void LateUpdate()
    {
        look.ProcessLook(player.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        player.Enable();
    }

    private void OnDisable()
    {
        player.Disable();
    }

   
}
