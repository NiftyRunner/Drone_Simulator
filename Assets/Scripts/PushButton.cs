using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Unity.VisualScripting;

public class PushButton : MonoBehaviour
{
    public UnityEvent buttonEvent;

    public float pressDistance = 0.02f; 
    public bool isPressed = false;
    public GameObject pressablePart;

    [SerializeField] bool isTextButton = false;
    [SerializeField] bool isCreditButton = false;
    [SerializeField] AssemblyManager assemblyManager;
    [SerializeField] AudioSource buttonSource;
    [SerializeField] GameObject introText;
    [SerializeField] GameObject creditText;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isPressed = true;
            pressablePart.transform.localPosition -= new Vector3(0, pressDistance, 0);
            buttonSource.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {

            Invoke("ButtonExit", 0.5f);

        }
    }

    void ButtonExit()
    {
        isPressed = false;
        pressablePart.transform.localPosition += new Vector3(0, pressDistance, 0);
        if (isTextButton)
        {
            isTextButton = false;
            isCreditButton = true;
            introText.SetActive(false);
            creditText.SetActive(true);
        }
        else if (isCreditButton)
        {
            isTextButton = true;
            isCreditButton = false;
            introText.SetActive(true);
            creditText.SetActive(false);
        }
        else
        {
            Invoke("ChangeScene", 0.5f);
        }
    }

    void ChangeScene()
    {
        buttonEvent.Invoke();
    }
    
    public void ToStart()
    {
        if (assemblyManager == null) { SceneManager.LoadScene("Start"); }
        
    }
    public void ToStop()
    {
        if (assemblyManager == null) { Application.Quit(); }
        
    }
    public void ToAssembly()
    {
        if(assemblyManager == null) { SceneManager.LoadScene("Assembly"); }
        
    }
    public void ToFlight()
    {
        if (assemblyManager != null && assemblyManager.isDroneCompleted)
        {
            SceneManager.LoadScene("Flight");
        }
    }
    
}


