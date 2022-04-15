using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermotot : MonoBehaviour
{
    private CharacterController Controller;

    private Vector3 playerVelocity;
    private bool isGrounded;

    public float speed = 5f;
    public float gravity = -9.8f;
    public float JumpHeight = 3f;

    private bool lerpCrouch;
    private bool crouching;
    private float crouchTimer = 0f;

    private bool sprinting;


    // Start is called before the first frame update
    void Start()
    {
        
        Controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                Controller.height = Mathf.Lerp(Controller.height, 1, p);
            else
                Controller.height = Mathf.Lerp(Controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        Controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        Controller.Move(playerVelocity * Time.deltaTime);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(JumpHeight * -3.0f * gravity);
        }
    }
    
    public void Crouching()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;

    }
    public void Running()
    {
       sprinting = !sprinting;
        if (sprinting)
            speed = 10f;
        else
            speed = 5f;
        
    }

  
}
