
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
    public bool wallRunL;
    public bool wallRunR;
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
        isWallRunning = true;
        
        
      

        if (playerLocomotion.playerRigidbody.velocity.magnitude <= maxWallSpeed)
        {
            playerLocomotion.playerRigidbody.AddForce(orientation.forward * wallrunForce * Time.deltaTime);
            

            if(wallRunTime < maxWallrunTime && playerLocomotion.isGrounded == false)
            {
                //Make sure char sticks to wall
                if (isWallRight && inputManager.horizontalInput != 0)
                {
                    wallRunR = true;
                    animatorManager.PlayTargetAnimation("WallRunR", true);
                    playerLocomotion.playerRigidbody.AddForce(orientation.right * wallrunForce / 5 * Time.deltaTime);
                    wallRunTime += Time.deltaTime;
                }
                    
                if(isWallLeft && inputManager.horizontalInput != 0)
                {   
                    wallRunL = true;
                    animatorManager.PlayTargetAnimation("WallRunL", true);
                    playerLocomotion.playerRigidbody.AddForce(-orientation.right * wallrunForce / 5 * Time.deltaTime);
                    wallRunTime += Time.deltaTime;
                }

                //sidwards wallhop
                if (isWallRight || isWallLeft && inputManager.horizontalInput == 1 || inputManager.horizontalInput == -1) playerLocomotion.playerRigidbody.AddForce(-orientation.up * jumpForce * 1f);
                if (isWallRight && inputManager.horizontalInput == -1) playerLocomotion.playerRigidbody.AddForce(-orientation.right * jumpForce * 3.2f);
                if (isWallLeft && inputManager.horizontalInput == 1) playerLocomotion.playerRigidbody.AddForce(orientation.right * jumpForce * 3.2f);

                //Always add forward force
                playerLocomotion.playerRigidbody.AddForce(orientation.forward * jumpForce * 1f);
                    
            }
            else
            {
                playerLocomotion.playerRigidbody.velocity += Vector3.down * wallGravityDownForce * Time.deltaTime;
            }
        }

        StopWallRun();
    }

    private void StopWallRun()
    {
        
        isWallRunning = false;
        wallRunL = false;
        wallRunR = false;
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
