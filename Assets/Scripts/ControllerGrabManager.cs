using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabManager : MonoBehaviour
{
    [SerializeField] int finalCount = 2;

    int grabCount = 0;

    public bool isGrabbingWithBothHands;

    void Start()
    {
        isGrabbingWithBothHands = false;
    }


    void Update()
    {
        if (grabCount == finalCount)
        {
            isGrabbingWithBothHands = true;
        }
        else
        {
            isGrabbingWithBothHands = false;
        }
    }

    public void OnGrab()
    {
        grabCount++;
        Debug.Log(grabCount);
    }

    public void OnRelease()
    {
        grabCount--;
        Debug.Log(grabCount);
    }
}
