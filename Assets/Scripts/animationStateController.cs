using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isRunningHash;
    int isJumpingHash;
    int isCrouchingHash;
    int isIdleHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
        isCrouchingHash = Animator.StringToHash("isCrouching");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool isCrouching = animator.GetBool(isCrouchingHash);
        bool runPressed = Input.GetKey("w");
        bool jumpPressed = Input.GetKey("space");
        bool crouchPressed = Input.GetKey("left ctrl");
        
        if(Input.GetKey("w"))
        {
            animator.SetBool(isRunningHash, true);
        }

        if(!Input.GetKey("w"))
        {
            animator.SetBool(isRunningHash, false);
        }

        if(Input.GetKeyDown("space"))
        {
            animator.SetBool(isJumpingHash, true);
        }

        if(!Input.GetKeyDown("space"))
        {
            animator.SetBool(isJumpingHash, false);
        }

        if(Input.GetKey("left ctrl"))
        {
            animator.SetBool(isCrouchingHash, true);
        }

        if(!Input.GetKey("left ctrl"))
        {
            animator.SetBool(isCrouchingHash, false);
        }
    }
}
