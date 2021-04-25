using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;
    AnimatorManager animatorManager;

    public GameObject winLoseScreen;
    public GameObject gameUI;
    public GameObject player;
    public Text thrownObjectText;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool b_Input;
    public bool jump_Input;

    public AudioSource musicSource;
    AudioSource audioSource;
    //public AudioClip mainmusic;


    [Header("Throw")]
    public bool throw_input;
    public bool return_input;
    private bool isReturning = false;
    public Rigidbody obj;
    public float throwForce = 50;
    Collider objCollider;
    private Vector3 oldPos;
    private float time = 0.0f;
    public Transform target;
    public Transform curvePoint;

    Collider playerColliderComponent;

    PauseAction pauseAction;
    public Text cheatText;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        objCollider = obj.GetComponent<Collider>();
        objCollider.enabled = !objCollider.enabled;
        obj.isKinematic = true;
        cheatText.text = " ";
       
        thrownObjectText.text = "Holding Ball";

        //musicSource.clip = mainmusic;
        //musicSource.Play();
        //musicSource.loop = true;
    }

    private void Start()
    {
        TimerController.instance.BeginTimer();
        playerColliderComponent = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.B.performed += i => b_Input = true;
            playerControls.PlayerActions.B.canceled += i => b_Input = false;

            //Throw
            playerControls.PlayerActions.Throw.performed += i => throw_input = true;
            playerControls.PlayerActions.Throw.canceled += i => throw_input = false;

            //Return
            playerControls.PlayerActions.Return.performed += i => return_input = true;
            playerControls.PlayerActions.Return.canceled += i => return_input = false;

            //Jump
            playerControls.PlayerActions.Jump.performed += i => jump_Input = true;
            

            //action map code to activate invincible cheat        
            pauseAction = new PauseAction();
            pauseAction.UI.Cheat.performed += _ => InvincibleCheat();
            pauseAction.Enable();
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        pauseAction.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSlidingInput();
        HandleJumpingInput();
        HandleThrowingInput();
        HandleReturningInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }

    private void HandleJumpingInput()
    {
        if(jump_Input)
        {
            jump_Input = false;
            
            animatorManager.PlayTargetAnimation("Jumping", false);
            animatorManager.animator.SetBool("isJumping", true);
        }
    }

    private void cancelJumping()
    {
        animatorManager.animator.SetBool("isJumping", false);
    }

    private void HandleSlidingInput()
    {
        if (b_Input && moveAmount > 0.5f)
        {
            playerLocomotion.isSliding = true;
        }
        else if(b_Input && (moveAmount == 0.0f))
        {
            playerLocomotion.isSliding = false;
            playerLocomotion.isCrouching = true;
        }
        else
        {
            playerLocomotion.isSliding = false;
            playerLocomotion.isCrouching = false;
        }
    }

    private void HandleThrowingInput()
    {
        if (throw_input)
        {
            animatorManager.PlayTargetAnimation("Throwing", true);
            thrownObjectText.text = "Ball thrown";
        }
       
    }

    private void Throw()
    {
        obj.transform.parent = null;
        objCollider.enabled = true;
        obj.isKinematic = false;
        obj.AddForce(UnityEngine.Camera.main.transform.TransformDirection(Vector3.forward) * throwForce, ForceMode.Impulse);
    }

    private void HandleReturningInput()
    {
        if(return_input)
        {
            time = 0.0f;
            oldPos = obj.position;
            isReturning = true;
            obj.position += target.position - obj.position;
            obj.velocity = Vector3.zero;
            obj.isKinematic = true;
            thrownObjectText.text = "Holding Ball";
        }

        if(isReturning)
        {
            //Return calc
            if(time < 1.0f)
            {
                obj.position = getBQCPoint(time, oldPos, curvePoint.position, target.position);
                obj.rotation = Quaternion.Slerp(obj.transform.rotation, target.rotation, 50 * Time.deltaTime);
                time += Time.deltaTime;
            }
            else
            {
                ResetObj();
            }
        }

    }

    void ResetObj()
    {
        isReturning = false;
        objCollider.enabled = false;
        obj.transform.parent = GameObject.Find ("mixamorig:RightHand").transform;
        obj.position = target.position;
        obj.rotation = target.rotation;
    }

    Vector3 getBQCPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
        return p;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishLevel1")
        {
            winLoseScreen.SetActive(true);
            player.SetActive(false);
            gameUI.SetActive(false);
            Cursor.visible = true;
            TimerController.instance.EndTimer();
            Destroy(other.gameObject);
        }
        
        if (other.tag == "FinishLevel2")
        {
            winLoseScreen.SetActive(true);
            player.SetActive(false);
            gameUI.SetActive(false);
            Cursor.visible = true;
            TimerController.instance.EndTimer();
            Destroy(other.gameObject);
        }

        if (other.tag == "FinishLevel3")
        {
            winLoseScreen.SetActive(true);
            player.SetActive(false);
            gameUI.SetActive(false);
            Cursor.visible = true;
            TimerController.instance.EndTimer();
            Destroy(other.gameObject);
        }
    }

    //push M key to activate invincible cheat
    public void InvincibleCheat()
    {
        if (playerColliderComponent.enabled == true)
        {
            playerColliderComponent.enabled = false;
            cheatText.text = "Invincible Mode ACTIVE";
        }
        else
        {
            playerColliderComponent.enabled = true;
            cheatText.text = " ";
        }
    }
}
