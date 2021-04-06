using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    Animator animator;

    int velocityXHash;
    int velocityZHash;
    int crouchHash;


    float velocityX = 0.0f;
    float velocityZ = 0.0f;

    public float speedLimit = 0.5f;

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

    #region velocity hundlers
    float speedHundle(bool LSpressed, float speedLimit)
    {
        //switching between walking and running smoothly
        if (LSpressed) speedLimit = 2.0f;
        if (!LSpressed && (speedLimit > 0.5f)) speedLimit = Mathf.Lerp(speedLimit, 0.5f, 0.005f);

        return speedLimit;
    }

    float forwardBackwardManeuvre(bool Zpress, bool Spress, float velocityZ, float speedLimit)
    {
        //accelerating forward
        if (Zpress)
        {
            velocityZ = speedLimit;
        }

        //accelerating backward
        if (Spress)
        {
            velocityZ = -speedLimit;
        }

        //deccelerating 
        if ((!Zpress && velocityZ >= 0.0f) || (!Spress && velocityZ <= 0.0f))
        {
            velocityZ = 0;
        }

        return velocityZ;
    }

    float leftRightManeuvre(bool Dpress, bool Qpress, float velocityX, float speedLimit)
    {
        //accelerating to the left
        if (Qpress)
        {
            velocityX = speedLimit;
        }

        //accelerating to the right
        if (Dpress)
        {
            velocityX = -speedLimit;
        }

        //deccelerating
        if ((!Qpress && velocityX >= 0.0f) || (!Dpress && velocityX <= 0.0f))
        {
            velocityX = 0;
        }

        return velocityX;
    }
    #endregion

    void Update()
    {
        #region Inputs
        //get input
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool backwardPressed = Input.GetKey(KeyCode.S);
        bool RightPressed = Input.GetKey(KeyCode.D);
        bool LeftPressed = Input.GetKey(KeyCode.A);

        bool runningPressed = Input.GetKey(KeyCode.LeftShift);
        bool crouchPressed = Input.GetKey(KeyCode.LeftControl);
        #endregion


        //call the velocity hundlers
        speedLimit = speedHundle(runningPressed, speedLimit);
        velocityZ = forwardBackwardManeuvre(forwardPressed, backwardPressed, velocityZ, speedLimit);
        velocityX = leftRightManeuvre(RightPressed, LeftPressed, velocityX, speedLimit);


        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("jump");
        }

        if (Input.GetKeyUp(KeyCode.Space)) animator.ResetTrigger("jump");


        //assign animation blending
        animator.SetFloat(velocityXHash, velocityX, 0.1f, Time.deltaTime);
        animator.SetFloat(velocityZHash, velocityZ, 0.1f, Time.deltaTime);
        animator.SetBool(crouchHash, crouchPressed);
    }
}
