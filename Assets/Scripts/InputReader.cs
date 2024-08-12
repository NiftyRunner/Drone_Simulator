using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static DroneController;

[CreateAssetMenu(menuName = "Drone/InputReader")]
public class InputReader : ScriptableObject, IDroneActions
{
    public event UnityAction<bool> DroneDown = delegate { };
    public event UnityAction<bool> DroneUp = delegate { };
    public event UnityAction<bool> DroneStand = delegate { };

    public Vector2 DroneMove => input.Drone.DroneMove.ReadValue<Vector2>();
    public Vector2 DroneTurn => input.Drone.DroneTurn.ReadValue<Vector2>();

    DroneController input;

    bool standIsEngaged = true;

    private void OnEnable()
    {
        if (input == null)
        {
            input = new DroneController();
            input.Drone.SetCallbacks(this);
        }
    }

    public void EnableInput() => input.Enable();
    public void DisableInput() => input.Disable();

    public void OnDroneDown(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                DroneDown.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                DroneDown.Invoke(false);
                break;
        }
    }
    public void OnDroneUp(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                DroneUp.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                DroneUp(false);
                break;
        }
    }

    public void OnDroneMove(InputAction.CallbackContext context) { }

    public void OnDroneTurn(InputAction.CallbackContext context) { }


    public void OnStand(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                standIsEngaged = !standIsEngaged;
                DroneStand.Invoke(standIsEngaged);
                break;
        }
    }
}
