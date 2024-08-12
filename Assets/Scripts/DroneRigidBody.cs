using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class DroneRigidBody : MonoBehaviour
{
    [Header("RigidBody Properties")]
    [SerializeField] private float weightInKg = 1.0f;

    protected Rigidbody rb;
    protected float startDrag;
    protected float startAngularDrag;

    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if(rb)
        {
            rb.mass = weightInKg;
            startDrag = rb.drag;
            startAngularDrag = rb.angularDrag;
        }
    }

    
    void FixedUpdate()
    {
        if(!rb)
        {return;}

        HandlePhysics();
    }

    protected virtual void HandlePhysics()
    {
        throw new NotImplementedException();
    }
}
