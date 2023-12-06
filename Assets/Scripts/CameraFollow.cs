using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform vehicle; //reference to the vehicle
    private Vector3 offset; //distance between cam and vehicle
    public float smoothSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - vehicle.position;
    }

    // Update is called once per frame
    void Update()
    {

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

        transform.LookAt(vehicle);
    }
}
