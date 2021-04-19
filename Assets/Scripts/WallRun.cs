
using System;
using UnityEngine;

public class WallRun : MonoBehaviour
{

    PlayerLocomotion playerLocomotion;
    AnimatorManager animatorManager;
    InputManager inputManager;
    
    //Wallrunning
    public LayerMask whatIsWall;
    public float wallrunForce;
    public float wallGravityDownForce = 20f;
    public float wallRunTime;
    public float maxWallrunTime;
    public float maxWallSpeed;
    public bool isWallRight;
    public bool isWallLeft;
    public bool isWallRunning;
 
    public Transform orientation;

    public float jumpForce;


    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        inputManager = GetComponent<InputManager>();
        
    }

    private void Update()
    {

        CheckForWall();
        WallRunInput();
        
        if(playerLocomotion.isGrounded == true)
            {
                wallRunTime = 0;
            }
        else
        {
             wallRunTime += Time.deltaTime;
         
        }
        
       
    }

    private void WallRunInput() //make sure to call in void Update
    {
      
        //Wallrun
        if ((inputManager.horizontalInput == 1) && isWallRight)
        {  
    
            StartWallrun();
        }
        
        if ((inputManager.horizontalInput == -1) && isWallLeft)
        {
           
            StartWallrun();
        }
    }

    private void StartWallrun()
    {
        
        
        playerLocomotion.playerRigidbody.useGravity = false;
        


        if (playerLocomotion.playerRigidbody.velocity.magnitude <= maxWallSpeed && (isWallRight || isWallLeft == true))
        {
            playerLocomotion.playerRigidbody.AddForce(orientation.forward * wallrunForce * Time.deltaTime);


            if(wallRunTime < maxWallrunTime && playerLocomotion.isGrounded == false )
            {
                //Make sure char sticks to wall
                if (isWallRight)
                {
                    animatorManager.PlayTargetAnimation("WallRunR", true);
                    playerLocomotion.playerRigidbody.AddForce(orientation.right * wallrunForce / 5 * Time.deltaTime, ForceMode.Impulse);
                    
                }
                    
                if(isWallLeft)
                {   
                
                    animatorManager.PlayTargetAnimation("WallRunL", true);
                    playerLocomotion.playerRigidbody.AddForce(-orientation.right * wallrunForce / 5 * Time.deltaTime, ForceMode.Impulse);
                    
                }

                //Always add forward force
                playerLocomotion.playerRigidbody.AddForce(orientation.forward * jumpForce * 1f);
                    
            }
            else
            {
                StopWallRun();
                playerLocomotion.playerRigidbody.velocity += Vector3.down * wallGravityDownForce * Time.deltaTime;
            }
        }

        StopWallRun();
    }

    private void StopWallRun()
    {
        isWallRunning = false;
        playerLocomotion.playerRigidbody.useGravity = true;
    }

    private void CheckForWall() //make sure to call in void Update
    {
        isWallRight = Physics.Raycast(transform.position, orientation.right, 1f, whatIsWall);
        isWallLeft = Physics.Raycast(transform.position, -orientation.right, 1f, whatIsWall);

        //leave wall run
        if (!isWallLeft && !isWallRight) StopWallRun();
       
    }


    
  
}
