using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
#pragma warning disable 649

    #region variables
    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
   
    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMvts;

    Vector2 horizentalInput;
    Vector2 mouseInput;
    #endregion


    private void Awake()
    {
        controls = new PlayerControls();
        groundMvts = controls.GroundMovement;

        // groundMvt.[action].performed += context => do something
        groundMvts.HorizentalMvt.performed += ctx => horizentalInput = ctx.ReadValue<Vector2>();
        groundMvts.Jump.performed += _ => movement.onJumpPressed();

        groundMvts.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMvts.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        movement.receiveInput(horizentalInput);
        mouseLook.recriveInput(mouseInput);
    }
}
