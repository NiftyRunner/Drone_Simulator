using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class CheckPointSystem : MonoBehaviour
{
    [SerializeField] GameObject drone;
    [SerializeField] AudioSource bgSource;
    //[SerializeField] AudioClip bgMusic;

    public List<GameObject> checkPoints = new List<GameObject>();
    public int currentCheckPoint;
    public TextMeshProUGUI stopwatchText;
    public bool isTimeActive;
    public bool isMusicActive;
    private float currentTime;

    void Start()
    {
        currentCheckPoint = 0;
        currentTime = 0f;
        isTimeActive = false;
        foreach (var checkPoint in checkPoints)
        {
            checkPoint.SetActive(false);
        }

    }
    void Update()
    {
        //if (checkPoints[currentCheckPoint] == null)
        //{
        //    StopTimer();
        //}


        checkPoints[currentCheckPoint].SetActive(true);

        if (isTimeActive)
        {
            StartTimer();
            StartMusic();
        }

        if(!isMusicActive)
        {
            bgSource.Stop();
        }
        UpdateStopwatchDisplay();
    }


    void StartMusic()
    {
        if (isMusicActive)
        {
            bgSource.Play();
            isMusicActive = false;
        }
        //bgSource.PlayOneShot(bgMusic);
    }

    private void StartTimer()
    {
        currentTime += Time.deltaTime;
    }

    void StopTimer()
    {
        isTimeActive = false;
        bgSource.Stop();
    }

    public void ResetStopwatch()
    {
        currentTime = 0f;
        isTimeActive = false;
        UpdateStopwatchDisplay();
    }

    void UpdateStopwatchDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        int milliseconds = Mathf.FloorToInt((currentTime * 1000f) % 1000f);
        string formattedTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        if (stopwatchText != null)
        {
            stopwatchText.text = formattedTime;
        }
    }

}
