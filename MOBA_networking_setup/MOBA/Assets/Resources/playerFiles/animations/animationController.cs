using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class animationController : MonoBehaviour
{
    Animator animator;
    GameObject myAvSet;
    PhotonView PV;

    int velocityXHash;
    int velocityZHash;
    int turnHash;

    int crouchHash;
    int jumpHash;
    int attackHash;

    PlayerControls input;
    Vector2 currentMvt;
    bool moving;
    bool sprinting;

    bool crounching;
    bool jumping;
    bool attacking;


    public float speedLimit;
    public float walkLimit = 1f;
    public float runLimit = 2f;

    void Awake()
    {
        //refer to the avatar instanciator for the photonView component
        PV = transform.parent.transform.parent.transform.parent.GetComponent<PhotonView>();

        //new input system listener instance
        input = new PlayerControls();

        //set the player input values using listeners
        input.GroundMovement.HorizentalMvt.performed += ctx =>
        {
            currentMvt = ctx.ReadValue<Vector2>();
            moving = currentMvt.x != 0 || currentMvt.y != 0;
        };
        input.GroundMovement.Sprint.performed += ctx => sprinting = ctx.ReadValueAsButton();
        input.GroundMovement.Crouch.performed += ctx => crounching = ctx.ReadValueAsButton();
        input.GroundMovement.Jump.performed += ctx => jumping = ctx.ReadValueAsButton();
        input.GroundMovement.Attack.performed += ctx => attacking = ctx.ReadValueAsButton();
    }

    // Start is called before the first frame update
    void Start()
    {
        // ref the animator
        animator = GetComponent<Animator>();

        //increase performance for animation seeking
        velocityXHash = Animator.StringToHash("velocityX");
        velocityZHash = Animator.StringToHash("velocityZ");
        crouchHash = Animator.StringToHash("crouching");
        jumpHash = Animator.StringToHash("jump");
        attackHash = Animator.StringToHash("attacking");
        turnHash = Animator.StringToHash("turn");
    }

    //update method
    void Update()
    {
        if (PV.IsMine)
        {
            animateMovement();
        }
    }

    void animateMovement()
    {
        // get animation values for checking
        float velocityX = animator.GetFloat(velocityXHash);
        float velocityY = animator.GetFloat(velocityZHash);
        float turn = animator.GetFloat(turnHash);

        bool crouch = animator.GetBool(crouchHash);
        bool attack = animator.GetBool(attackHash);
        bool jump = animator.GetBool(jumpHash);

        //assigning walk/run values
        speedLimit = sprinting ? Mathf.Lerp(speedLimit, runLimit, 0.05f) : Mathf.Lerp(speedLimit, walkLimit, 0.05f);

        //forward/backward acceleration/decceleration in the animator values
        if (moving)
        {
            animator.SetFloat(velocityXHash, speedLimit * currentMvt.normalized.x);
            animator.SetFloat(velocityZHash, speedLimit * currentMvt.normalized.y);
        }else
        {
            animator.SetFloat(velocityXHash, 0);
            animator.SetFloat(velocityZHash, 0);
        }


    }

    void OnEnable()
    {
        input.GroundMovement.Enable();
    }
    void OnDisable()
    {
        input.GroundMovement.Disable();
    }
}
