using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NiFTY
{
    [RequireComponent(typeof(BoxCollider))]
    public class DroneEngine : MonoBehaviour, IEngine
    {
        [SerializeField] bool droneUp = false;
        [SerializeField] bool droneDown = false;
        [SerializeField] bool isStandEnabled = true;
        [SerializeField] private float maxPower = 4f;

        [SerializeField] private Transform propeller;
        [SerializeField] private float propRotSpeed = 300f;

        [SerializeField] InputReader input;
        [SerializeField] GameObject stand;

        void OnEnable()
        {
            input.DroneUp += OnDroneUp;
            input.DroneDown += OnDroneDown;
            input.DroneStand += OnDroneStand;
        }

        void OnDisable()
        {
            input.DroneDown -= OnDroneDown;
            input.DroneUp -= OnDroneUp;
            input.DroneStand -= OnDroneStand;
        }

        void OnDroneUp(bool isPressed)
        {
            if (isPressed)
            {
                droneUp = true;
            } else
            {
                droneUp = false;
            }
        }

        void OnDroneDown(bool isPressed)
        {
            if (isPressed)
            {
                droneDown = true;
            }
            else
            {
                droneDown= false;
            }
        }

        void OnDroneStand(bool isPressed)
        {
            if (isPressed)
            {
                isStandEnabled = false;
                stand.SetActive(isStandEnabled);
            }
            else
            {
                isStandEnabled = true;
                stand.SetActive(isStandEnabled);
            }

        }

        public void InitEngine()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEngine(Rigidbody rb, InputReader input)
        {
            //Debug.Log("Running Engine " +gameObject.name);
            Vector3 upVec = transform.up;
            upVec.x = 0f;
            upVec.z = 0f;
            float diff = 1 - upVec.magnitude;
            float finalDiff = Physics.gravity.magnitude * diff;

            Vector3 engineForce = Vector3.zero;

            int yValue = 0;
            if (droneUp)
            {
                yValue = 1;
            }
            else if (droneDown)
            {
                yValue = -1;
            }
            else
            {
                yValue = 0;
            }


            engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude + finalDiff) + (yValue * maxPower)) / 4f;
            rb.AddForce(engineForce, ForceMode.Force);

            HandlePropellers();
        }

        void HandlePropellers()
        {
            if (!propeller)
            { return; }
        
            propeller.Rotate(Vector3.up, propRotSpeed);
        }
    }
}