using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyManager : MonoBehaviour
{
    [SerializeField] int finalCount = 3;
    [SerializeField] AudioSource clickSource;

    int currentCount = 0;

    public bool isDroneCompleted;


    void Update()
    {
        if (currentCount == finalCount)
        {
            isDroneCompleted = true;
            Debug.Log("Drone Finished");

        }
    }

    public void OnConnect()
    {
        currentCount++;
        clickSource.Play();
        Debug.Log(currentCount); 
    }

    public void OnDisconnect()
    {
        currentCount--;
        Debug.Log(currentCount);
    }
}
