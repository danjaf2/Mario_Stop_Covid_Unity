using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    public float Speed;
    public CharacterController control;
    public Animator animation;
    public Transform camera;
    float cameraSpeedFollow = 0.1f;
    float cameraVelocity;
    private float jumpHeight = 30f;
    private float gravityValue = -10.0f;
    Vector3 movDir;
    private bool inWind=false;
    public GameObject windZone;
    private void Start()
    {
        animation.speed = 2f;
        control = this.GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (inWind)
        {
            control.Move(windZone.GetComponent<Wind>().direction* windZone.GetComponent<Wind>().strengh);
        }
    }

    void Update ()
    {

        PlayerMovement();
       
       movDir.y += gravityValue * Time.deltaTime;
        
        PlayerJump();
     
        
        if (movDir.y<0)
        {
            if (control.isGrounded)
            {
                control.Move(new Vector3(movDir.normalized.x * Speed * -movDir.y, movDir.normalized.y * jumpHeight, movDir.normalized.z * Speed * -movDir.y) * Time.deltaTime);
            }
            else
            {
                control.Move(new Vector3(movDir.normalized.x * Speed *0.95f, movDir.normalized.y * jumpHeight, movDir.normalized.z * Speed * 0.95f) * Time.deltaTime);
            }
            
        }
        else if (movDir.y > 0)
        {
            if (control.isGrounded)
            {
                control.Move(new Vector3(movDir.normalized.x * Speed * movDir.y, movDir.normalized.y * jumpHeight, movDir.normalized.z * Speed * movDir.y) * Time.deltaTime);
            }
            else
            {
                control.Move(new Vector3(movDir.normalized.x * Speed * 0.95f, movDir.normalized.y * jumpHeight, movDir.normalized.z * Speed * 0.95f) * Time.deltaTime);
            }
        }



        movDir = new Vector3(0, movDir.y, 0);

    }

    private void PlayerJump()
    {
        if (control.isGrounded && Input.GetButtonDown("Jump"))
        {
            animation.SetBool("Jump", true);
            animation.SetBool("Run", false);
            Debug.Log("Jumpin");
            movDir.y = 3;
        }
        
            
        
      
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (hor == 0 && ver == 0)
        {
            animation.SetBool("Run", false);
            movDir.x = 0;
            movDir.z = 0;
        }
        else
        {
            if (control.isGrounded||inWind)
            {
                animation.SetBool("Run", true);
            }
            else
            {
                animation.SetBool("Run", false);
            }
            
        }


        if (control.isGrounded)
        {
            animation.SetBool("Jump", false);
        }
        Vector3 direction = new Vector3(hor, 0f, ver).normalized;
        Vector3 finalDir= new Vector3(0,0,0);
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref cameraVelocity, cameraSpeedFollow);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            finalDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
          
                movDir.x = finalDir.x;
                movDir.z = finalDir.z;
            
        }
        
        

        //transform.Translate(playerMovement, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            inWind = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            inWind = false;
        }
    }

   
}