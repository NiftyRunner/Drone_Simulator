
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows;

namespace NiFTY
{
    [RequireComponent(typeof(DroneInput))]
    public class DroneHandlerNew : DroneRigidBody
    {
        [Header("Controller Properties")]
        [SerializeField] private float minMaxPitch = 30f;
        [SerializeField] private float minMaxRoll = 30f;
        [SerializeField] private float yawPower = 4f;
        [SerializeField] private float lerpSpeed = 2f;

        [SerializeField] InputReader input;
        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioClip crashClip;

        private List<IEngine> engines = new List<IEngine>();

        private float finalPitch;
        private float finalRoll;
        private float yaw;
        private float finalYaw;

        void Start()
        {
            engines = GetComponentsInChildren<IEngine>().ToList<IEngine>();
            audioSource.Play();
        }


        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleControls();
        }

        protected virtual void HandleControls()
        {
            Debug.Log($"Drone turn: {input.DroneTurn}, Drone move: {input.DroneMove}");

            float pitch = input.DroneMove.y * minMaxPitch;
            float roll = -input.DroneMove.x * minMaxRoll;
            yaw += input.DroneTurn.x * yawPower;
            //yaw += input.Pedals * yawPower;

            finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
            finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
            finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);

            Quaternion rot = Quaternion.Euler(finalPitch, finalYaw, finalRoll);
            rb.MoveRotation(rot);
        }

        protected virtual void HandleEngines()
        {
            //rb.AddForce(Vector3.up * (rb.mass * Physics.gravity.magnitude));
            foreach (IEngine engine in engines)
            {
                engine.UpdateEngine(rb, input);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            audioSource.PlayOneShot(crashClip);
        }
    }
}