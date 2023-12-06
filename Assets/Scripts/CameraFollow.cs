using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform vehicle; //reference to the vehicle
    private Vector3 offset; //distance between cam and vehicle
    public float smoothSpeed = 0.1f;
    public bool isThirdPersonCam = false;
    //public Vector3 thirdPerson = new Vector3(0, 0, 0);
    //public Vector3 firstPerson = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - vehicle.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.F)) This test to change the camera position didn't work, moved to a seperate script
        //{
        //    transform.position = firstPerson + vehicle.position + offset;
        //}

        //if (Input.GetKey(KeyCode.T))
        //{
        //    transform.position = thirdPerson + vehicle.position + offset;
        //}
    }

    private void LateUpdate() //Last thing to be called on a frame
    {
        MoveCamWithLerp();
    }

    private void MoveCamWithoutLerp() //Move cam without smoothing the values
    {
        transform.position = vehicle.position + offset;
    }

    private void MoveCamWithLerp() //Move cam using Lerp to smooth out the values
    {
        Vector3 expectedPosition = vehicle.position + offset;

        Vector3 smoothPosition = Vector3.Lerp(transform.position, expectedPosition, smoothSpeed);

        transform.position = smoothPosition;

        if (isThirdPersonCam == true)
        {
            transform.LookAt(vehicle);
        }
        
    }
}
