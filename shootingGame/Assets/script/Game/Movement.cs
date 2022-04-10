using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    
    // Update is called once per frame
    void Update()
    {
        //the fuction of the object if object touch the ground and recognize it.  
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;//move in de x and z axis

        controller.Move(move * speed * Time.deltaTime);//movement of the object

        if (Input.GetButtonDown("Jump") && isGrounded)
        {//jumping but it doesn't work
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("jump");
        }

        velocity.y += gravity * Time.deltaTime;// move + gravity over time

        controller.Move(velocity * Time.deltaTime);
    }
}
