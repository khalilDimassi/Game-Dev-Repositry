using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{

    Animator animator;

    int velocityXHash;
    int velocityZHash;
    int crouchHash;

    bool isGrounded;

    float velocityX = 0.0f;
    float velocityZ = 0.0f;
    bool crouch = false;

    public float acceleration = 0.1f;
    float deceleration;
    float speedLimit = 0.5f;

    // Start is called before the first frame update
    void Start()    
    {   
        // ref the animator
        animator = GetComponent<Animator>();

        //increase performance for animation seeking
        velocityXHash = Animator.StringToHash("velocityX");
        velocityZHash = Animator.StringToHash("velocityZ");
        crouchHash = Animator.StringToHash("crouching");
    }

    //velocity hundlers
    float speedHundle(bool LSpressed, float speedLimit)
    {
        //switching between walking and running smoothly
        if (LSpressed) speedLimit = 2.0f;
        if (!LSpressed && (speedLimit > 0.5f)) speedLimit = Mathf.Lerp(speedLimit, 0.5f, 0.005f);

        return speedLimit;
    }

    float forwardBackwardManeuvre(bool Zpress, bool Spress, float velocityZ, float acceleration, float deceleration, float speedLimit)
    {
        //accelerating forward
        if (Zpress)
        {
            velocityZ += Time.deltaTime * acceleration;
            if (velocityZ > speedLimit) velocityZ = speedLimit;
        }

        //accelerating backward
        if (Spress)
        {
            velocityZ -= Time.deltaTime * acceleration;
            if (velocityZ < -speedLimit) velocityZ = -speedLimit;
        }

        //deccelerating backward
        if (!Zpress && velocityZ >= 0.0f)
        {
            velocityZ += Time.deltaTime * deceleration;
            if (velocityZ < 0.0f) velocityZ = 0.0f;
        }

        //deccelerating forward
        if (!Spress && velocityZ <= 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
            if (velocityZ > 0.0f) velocityZ = 0.0f;
        }
        return velocityZ;
    }

    float leftRightManeuvre(bool Dpress, bool Qpress, float velocityX, float acceleration, float deceleration, float speedLimit)
    {
        //accelerating to the left
        if (Qpress)
        {
            velocityX += Time.deltaTime * acceleration;
            if (velocityX > speedLimit) velocityX = speedLimit;
        }

        //deccelerating from the left
        if (!Qpress && velocityX >= 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
            if (velocityX < 0.0f) velocityX = 0.0f;
        }

        //accelerating to the right
        if (Dpress)
        {
            velocityX -= Time.deltaTime * acceleration;
            if (velocityX < -speedLimit) velocityX = -speedLimit;
        }

        //deccelerating from the right
        if (!Dpress && velocityX <= 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
            if (velocityX > 0.0f) velocityX = 0.0f;
        }
        return velocityX;
    }


    void Update()
    {
        //fix deccelration value
        deceleration = -acceleration;

        //get input
        bool forwardPressed = Input.GetKey(KeyCode.Z);
        bool backwardPressed = Input.GetKey(KeyCode.S);
        bool RightPressed = Input.GetKey(KeyCode.D);
        bool LeftPressed = Input.GetKey(KeyCode.Q);

        bool runningPressed = Input.GetKey(KeyCode.LeftShift);
        bool crouchPressed = Input.GetKey(KeyCode.LeftControl);
        

        //call the velocity hundlers
        speedLimit = speedHundle(runningPressed, speedLimit);
        velocityZ = forwardBackwardManeuvre(forwardPressed, backwardPressed, velocityZ, acceleration, deceleration, speedLimit);
        velocityX = leftRightManeuvre(RightPressed, LeftPressed, velocityX, acceleration, deceleration, speedLimit);


        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("jump");
            velocityX = 0;
            velocityZ = 0;
        }


        //assign animation blending
        animator.SetFloat(velocityXHash, velocityX);
        animator.SetFloat(velocityZHash, velocityZ);
        animator.SetBool(crouchHash, crouchPressed);
    }
}
