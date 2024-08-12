using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHands : MonoBehaviour
{

    [SerializeField] InputActionProperty pinchAnimAction;
    [SerializeField] InputActionProperty grabAnimAction;
    Animator handAnim;

    public bool isPinching { get; private set; } = false;

    float pinchThreshold = 0.7f;
    float pinchVal;
    
    void Start()
    {
        handAnim = GetComponent<Animator>();
    }

    void Update()
    {
        pinchVal = pinchAnimAction.action.ReadValue<float>();
        handAnim.SetFloat("Trigger", pinchVal);

        float grabVal = grabAnimAction.action.ReadValue<float>();
        handAnim.SetFloat("Grip", grabVal);

        if (pinchVal < pinchThreshold)
            isPinching = false;
        else
            isPinching = true;   
    }

}
