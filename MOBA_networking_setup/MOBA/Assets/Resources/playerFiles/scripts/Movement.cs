using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
#pragma warning disable 649

    #region variables
    Vector2 horizentalInput;
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;

    [SerializeField] LayerMask groundMask;
    bool isGrounded;
    [SerializeField] float gravity = -30f;
    Vector3 verticalVelocity;

    [SerializeField] float jumpheight = 3.5f;
    bool jump;

    private PhotonView PV;
    #endregion


    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    public void receiveInput(Vector2 _horizentalInput)
    {
        horizentalInput = _horizentalInput;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

    void Update()
    {
        moving();
        jumping();
    }

    private void jumping()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.2f, groundMask);
        if (isGrounded)
        {
            verticalVelocity.y = 0;
        }
        //jump: v = sqrt(-2 * jumpHeight * gravity)
        if (jump && isGrounded)
        {
            verticalVelocity.y = Mathf.Sqrt(-2f * jumpheight * gravity);
            jump = false;
        }
        verticalVelocity.y += gravity * Time.deltaTime;

        if (PV.IsMine)
        {
            controller.Move(verticalVelocity * Time.deltaTime);
        }
    }

    private void moving()
    {
        Vector3 horizentalVelocity = (transform.right * horizentalInput.x + transform.forward * horizentalInput.y) * speed;

        if (PV.IsMine)
        {
            controller.Move(horizentalVelocity * Time.deltaTime);
        }
    }

    public void onJumpPressed()
    {
        if (isGrounded)
        {
            jump = true;
        }
    }
}
