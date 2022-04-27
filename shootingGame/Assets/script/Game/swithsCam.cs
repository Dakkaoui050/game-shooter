using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class swithsCam : MonoBehaviour
{
    [SerializeField] private PlayerInput playerinput;
    [SerializeField] private int BoostAmount = 10;

    private CinemachineVirtualCamera VirtualCamera;
    private PlayerInput.PlayerActions Player;
    private InputAction aimAction;

    private void Awake()
    {
        VirtualCamera = GetComponent<CinemachineVirtualCamera>();
        //aimAction = playerinput.Player["Aim"];
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }
    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }
    private void StartAim()
    {
        VirtualCamera.Priority += BoostAmount;
    }
    private void CancelAim()
    {
        VirtualCamera.Priority -= BoostAmount;
    }
}
