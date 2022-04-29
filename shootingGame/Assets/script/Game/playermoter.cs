using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playermoter : MonoBehaviour
{
    private CharacterController Controller;

    public ParticleSystem muzzels;
   

    private Vector3 playerVelocity;
    private bool isGrounded;

    public float speed = 5f;
    public float gravity = -9.8f;
    public float JumpHeight = 3f;

    private bool lerpCrouch;
    private bool crouching;
    private float crouchTimer = 0f;

    private bool sprinting;

    public int gunDamage;

    private bool Aim;
    public GameObject Cam;
    public GameObject aiming;

    health health;

    // Start is called before the first frame update
    void Awake()
    {

        Controller = GetComponent<CharacterController>();
        health = GetComponent<health>();
        
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

        //character controller move Direction * with de speed
        Controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        //if your fall from a height 
        playerVelocity.y += gravity * Time.deltaTime;
        //moving forward
        Controller.Move(playerVelocity * Time.deltaTime);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;

        }

    }

    public void Jump()
    {
        //jumping function 
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
        //run function
        sprinting = !sprinting;
        if (sprinting)
        {
            speed = 10f;

        }
        else
        {
            speed = 5f;

        }

    }
    public void Aiming()
    {
        // switching from normal cam to Aim Cam and reversed
        Aim = !Aim;
        if(Aim)
        {
            aiming.SetActive(true);
            Cam.SetActive(false);
        }
        else
        {
            //I do it this way because otherwise it won't work
            ResetCameras();
        }


    }
    public void ResetCameras()
    {
        Cam.SetActive(true);
        aiming.SetActive(false);
    }

    public void Shoot()
    {
       

        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position,Cam.transform.forward,out hit))
        {
             muzzels.Play();

            Debug.Log("Hit Something" + hit.transform.name);

            health = hit.transform.GetComponent<health>();
            if(health != null)
            {
                health.Damage(gunDamage);
            }
        }

        if (Physics.Raycast(aiming.transform.position, aiming.transform.forward, out hit))
        {
            //Bullet();
            muzzels.Play();
            Debug.Log("Hit Something wel aiming" + hit.transform.name);

            health = hit.transform.GetComponent<health>();
            if (health != null)
            {
                health.Damage(gunDamage);
            }
        }

       
    }

   
}
