using NiFTY;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FlightSceneMovementManager : MonoBehaviour
{
    [SerializeField] LocomotionSystem playerMove;
    [SerializeField] ActionBasedContinuousMoveProvider playerMover;
    [SerializeField] ActionBasedContinuousTurnProvider playerTurner;
    [SerializeField] DroneHandler droneMove;
    [SerializeField] DroneInput droneInput;
    [SerializeField] PlayerInput droneControlInput;

    [SerializeField] ControllerGrabManager controllerGrabManager;

    [SerializeField] InputReader input;

    void Start()
    {
        playerMove.enabled = true;
        playerMover.enabled = true;
        playerTurner.enabled = true;
        //droneMove.enabled = false;
        //droneInput.enabled = false;
        //droneControlInput.enabled = false;

        input.DisableInput();
    }


    void Update()
    {
        if (controllerGrabManager.isGrabbingWithBothHands)
        {
            playerMove.enabled = false;
            playerMover.enabled = false;
            playerTurner.enabled = false;
            //droneMove.enabled = true;
            //droneInput.enabled = true;
            //droneControlInput.enabled = true;

            input.EnableInput();
        }
        else
        {
            playerMove.enabled = true;
            playerMover.enabled = true;
            playerTurner.enabled = true;
            //droneMove.enabled = false;
            //droneInput.enabled = false;
            //droneControlInput.enabled = false;

            input.DisableInput();
        }
    }
}
