using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] Transform head; 

    void Update()
    {
        if (head != null)
        {
            transform.LookAt(new Vector3(head.position.x, head.position.y, head.position.z));

        }
    }
}
