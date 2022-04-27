using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class input : MonoBehaviour
{

    private PlayerInput playerinput;
    private PlayerInput.PlayerActions Player;
    private Vector2 Movement;
    private InputAction movement;    

    private playermoter motot;
    private PlayerLook look;
    

    private void Awake()
    {

        playerinput = new PlayerInput();
        Player = playerinput.Player;
        motot = GetComponent<playermoter>();
        look = GetComponent<PlayerLook>();
        Player.Jump.performed += ctx => motot.Jump();
        Player.Aim.performed += _ => motot.Aiming();
        Player.Aim.canceled += _ => motot.Aiming();
        

        //Player.Run.performed += ctx => motot.Running();
        //Player.Crouch.performed += ctx => motot.Crouching();

    }

    private void FixedUpdate()
    {
        motot.ProcessMove(Player.Movement.ReadValue<Vector2>());


    }
    private void LateUpdate()
    {
        look.ProcessLook(Player.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        Player.Enable();
    }

    private void OnDisable()
    {
        Player.Disable();
    }

}
