using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playinput : MonoBehaviour
{
    private PlayerInput playerinput;
    private PlayerInput.PlayerActions player;
    private Vector2 Movement;
    private InputAction movement;
  
    public playermotot motot;
    public PlayerLook look;

    private void Awake()
    {
        playerinput = new PlayerInput();
        player = playerinput.Player;
        motot = GetComponent<playermotot>();
        look = GetComponent<PlayerLook>();
        player.Jump.performed += ctx => motot.Jump();
        player.Run.performed += ctx => motot.Running();
        player.Crouch.performed += ctx => motot.Crouching();
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
