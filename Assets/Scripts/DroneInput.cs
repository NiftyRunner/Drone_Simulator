using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerInput))]
public class DroneInput : MonoBehaviour
{

    private Vector2 cyclic;
    //private float pedals;
    private Vector2 pedals;
    private float throttle;
    [SerializeField] bool isStandActive;

    public Vector2 Cyclic { get => cyclic; }
    //public float Pedals { get => pedals; }
    public Vector2 Pedals { get => pedals; }
    public float Throttle { get => throttle; }

    [SerializeField] GameObject stand_1;
    [SerializeField] GameObject stand_2;

    private void Start()
    {
        isStandActive = true;
    }

    private void OnCyclic(InputValue value)
    {
        cyclic = value.Get<Vector2>();
    }

    //private void OnDroneMove(InputValue value)
    //{
    //    cyclic = value.Get<Vector2>();
    //}

    //private void OnMove(InputValue value)
    //{
    //    cyclic = value.Get<Vector2>();
    //}

    private void OnPedals(InputValue value)
    {
        //pedals = value.Get<float>();
        pedals = value.Get<Vector2>();
        //Debug.Log("Pedals: " + pedals);
    }

    //private void OnDroneTurn(InputValue value)
    //{
    //    //pedals = value.Get<float>();
    //    pedals = value.Get<Vector2>();
    //}

    //private void OnTurn(InputValue value)
    //{
    //    //pedals = value.Get<float>();
    //    pedals = value.Get<Vector2>();
    //}

    private void OnThrottle(InputValue value)
    {
        
        throttle = value.Get<float>();
        //Debug.Log("Throttle:" +throttle);
    }

    //private void OnDroneUp(InputValue value)
    //{
    //    throttle = value.Get<float>();
    //}

    //private void OnActivate(InputValue value)
    //{
    //    throttle = value.Get<float>();
    //}

    //private void OnDroneDown(InputValue value)
    //{
    //    throttle = value.Get<float>();
    //}

    private void OnStand(InputValue value)
    {
        if (isStandActive)
        {
            stand_1.SetActive(!isStandActive);
            stand_2.SetActive(!isStandActive);
            isStandActive = !isStandActive;
        }
        else if (!isStandActive)
        {
            stand_1.SetActive(!isStandActive);
            stand_2.SetActive(!isStandActive);
            isStandActive = !isStandActive;
        }
            
    }
}
