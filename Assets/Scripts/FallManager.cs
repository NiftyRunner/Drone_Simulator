using UnityEngine;

public class FallManager : MonoBehaviour
{
    //Transform initialPosition;
    Vector3 positionVector;
    Quaternion rotationQuaternion;

    private void Start()
    {
        //initialPosition = GetComponent<Transform>();
        //initialPosition = transform;
        positionVector = transform.position;
        rotationQuaternion = transform.rotation;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bottom")
        {
            //Debug.Log("Bottom Triggered");
            //this.transform.position = initialPosition.position;
            this.transform.position = positionVector;
            this.transform.rotation = rotationQuaternion;
        }
    }
}
