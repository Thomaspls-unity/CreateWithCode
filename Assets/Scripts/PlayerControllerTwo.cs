using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControllerTwo : MonoBehaviour
{
    public float horizontalInputTwo;
    public float verticalInputTwo;
    public float speedTwo = 20.0f;
    public float defaultSpeedTwo = 20.0f;
    public float sprintSpeedTwo = 40.0f;
    public float rotateSpeedTwo = 60.0f;
    public Rigidbody playerTwoRb;
    // Start is called before the first frame update
    void Start()
    {
        playerTwoRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputTwo();
        //SpeedBoost();
    }

    public void GetInputTwo()
    {
        horizontalInputTwo = Input.GetAxis("Horizontal2");
        verticalInputTwo = Input.GetAxis("Vertical2");
    }

    private void FixedUpdate()
    {
        MoveCarWithForceAndTorqueTwo();
        MoveCarWithPhysicsRotationTwo();
    }

    private void MoveCarWithForceAndTorqueTwo()
    {
        if (verticalInputTwo > 0.01f || verticalInputTwo < -0.01f)
        {
            playerTwoRb.AddForce(transform.forward * verticalInputTwo * speedTwo);
        }

        if (horizontalInputTwo > 0.01f || horizontalInputTwo < -0.01f)
        {
            playerTwoRb.AddTorque(transform.up * horizontalInputTwo * rotateSpeedTwo);
        }
    }

    private void MoveCarWithPhysicsRotationTwo()
    {
        //Vector3 moveDirection = new Vector2(horizontalInput, verticalInput);
        Vector3 moveDirection = transform.forward * verticalInputTwo;
        playerTwoRb.MovePosition(playerTwoRb.position + moveDirection * speedTwo * Time.fixedDeltaTime);

        if (horizontalInputTwo > 0.01f || horizontalInputTwo < -0.01f)
        {
            float turnSpeed = horizontalInputTwo * rotateSpeedTwo * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turnSpeed, 0f);
            playerTwoRb.MoveRotation(playerTwoRb.rotation * turnRotation);
        }
    }

    public void SpeedBoost()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            speedTwo = sprintSpeedTwo;
        }
        else
        {
            speedTwo = defaultSpeedTwo;
        }
    }
}
