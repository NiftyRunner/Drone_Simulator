using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI startingText;
    [SerializeField] bool isStartingPoint;
    [SerializeField] bool isEndingPoint;
    [SerializeField] AudioSource pointSource;
    [SerializeField] AudioClip pointClip;
    [SerializeField] AudioClip winClip;
    CheckPointSystem checkPointSystem;
    int currentPoint;

    void Start()
    {
        checkPointSystem = GetComponentInParent<CheckPointSystem>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Drone Crossed");

            if (isStartingPoint)
            {
                StartPoint();
            }

            if (!isEndingPoint)
            {
                checkPointSystem.currentCheckPoint += 1;
                pointSource.PlayOneShot(pointClip);
            }
            else
            {
                EndPoint();
            }

            this.gameObject.SetActive(false);
        }
    }

    void StartPoint()
    {
        checkPointSystem.ResetStopwatch();
        startingText.enabled = false;
        checkPointSystem.isTimeActive = true;
        checkPointSystem.isMusicActive = true;
    }

    void EndPoint()
    {
        startingText.enabled = true;
        checkPointSystem.isTimeActive = false;
        checkPointSystem.isMusicActive = false;
        checkPointSystem.checkPoints[0].SetActive(true);
        checkPointSystem.currentCheckPoint = 0;
        pointSource.PlayOneShot(winClip);
    }
}
