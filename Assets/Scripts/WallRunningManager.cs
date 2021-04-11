using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallRunningManager : MonoBehaviour
{      
    PlayerLocomotion playerLocomotion;
    InputManager inputManager;
    AnimatorManager animatorManager;
    
    [Header("Wall Running")]
    public float wallMaxDistance = 1;
    public float wallSpeedMultiplier = 1.2f;
    public float minimumHeight = 1.2f;
    [Range(0.0f, 1.0f)]
    public float normalizedAngleThreshold = 0.1f;

    public float jumpDuration = 1;
    public float wallBouncing = 3;
    public float wallGravityDownForce = 20f;

    Vector3[] directions;
    RaycastHit[] hits;

    public bool isWallRunning = false;
    Vector3 lastWallPosition;
    Vector3 lastWallNormal;
    float elapsedTimeSinceJump = 0;
    float elapsedTimeSinceWallAttach = 0;
    float elapsedTimeSinceWallDetatch = 0;
    bool jumping;

    bool isPlayergrounded() => playerLocomotion.isGrounded;
    public bool IsWallRunning() => isWallRunning;

    bool CanWallRun()
    {
        float verticalAxis = inputManager.verticalInput;
        
        return !isPlayergrounded() && (verticalAxis > 0 || verticalAxis < 0) && VerticalCheck();
    }

    bool VerticalCheck()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minimumHeight);
    }

     void Start()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
        inputManager = GetComponent<InputManager>();
        animatorManager = GetComponent<AnimatorManager>();

         directions = new Vector3[]{ 
            Vector3.right, 
            Vector3.right + Vector3.forward,
            Vector3.forward, 
            Vector3.left + Vector3.forward, 
            Vector3.left
        };

    }

    public void LateUpdate()
    {
        isWallRunning = false;

        if(CanAttach())
        {
            hits = new RaycastHit[directions.Length];

            for(int i=0; i<directions.Length; i++)
            {
                Vector3 dir = transform.TransformDirection(directions[i]);
                Physics.Raycast(transform.position, dir, out hits[i], wallMaxDistance);
                if(hits[i].collider != null)
                {
                    Debug.DrawRay(transform.position, dir * hits[i].distance, Color.green);
                }
                else
                {
                    Debug.DrawRay(transform.position, dir * wallMaxDistance, Color.red);
                }
            }

            if(CanWallRun())
            {   
                hits = hits.ToList().Where(h => h.collider != null).OrderBy(h => h.distance).ToArray();
                if(hits.Length > 0)
                {
                    OnWall(hits[0]);
                    lastWallPosition = hits[0].point;
                    lastWallNormal = hits[0].normal;
                }
            }

             if(isWallRunning)
            {   
                elapsedTimeSinceWallDetatch = 0;
        
                elapsedTimeSinceWallAttach += Time.deltaTime;
                playerLocomotion.playerRigidbody.velocity += Vector3.down * wallGravityDownForce * Time.deltaTime;
                
            }
            else
            {   
                elapsedTimeSinceWallAttach = 0;
                elapsedTimeSinceWallDetatch += Time.deltaTime;
            }
        }

       
    } 

    bool CanAttach()
        {
            if(jumping)
            {
                elapsedTimeSinceJump += Time.deltaTime;
                if(elapsedTimeSinceJump > jumpDuration)
                {
                    elapsedTimeSinceJump = 0;
                    jumping = false;
                }
                return false;
            }
            
            return true;
        }

        void OnWall(RaycastHit hit)
        {
            float d = Vector3.Dot(hit.normal, Vector3.up);
            if(d >= -normalizedAngleThreshold && d <= normalizedAngleThreshold)
            {
                // Vector3 alongWall = Vector3.Cross(hit.normal, Vector3.up);
                float vertical = inputManager.verticalInput;
                Vector3 alongWall = transform.TransformDirection(Vector3.forward);

                Debug.DrawRay(transform.position, alongWall.normalized * 10, Color.green);
                Debug.DrawRay(transform.position, lastWallNormal * 10, Color.magenta);

                playerLocomotion.playerRigidbody.velocity = alongWall * vertical * wallSpeedMultiplier;
                isWallRunning = true;

                if( d > 0)
                {
                    animatorManager.animator.SetFloat("Horizontal", 3);
                }
                else
                {
                    animatorManager.animator.SetFloat("Horizontal", 2);
                }


            
            }
        }

        float CalculateSide()
        {
            if(isWallRunning)
            {
                Vector3 heading = lastWallPosition - transform.position;
                Vector3 perp = Vector3.Cross(transform.forward, heading);
                float dir = Vector3.Dot(perp, transform.up);
                return dir;
            }
            return 0;
        }

        public Vector3 GetWallJumpDirection()
        {
            if(isWallRunning)
            {
                return lastWallNormal * wallBouncing + Vector3.up;
            }
            return Vector3.zero;
        } 

 
    
}
