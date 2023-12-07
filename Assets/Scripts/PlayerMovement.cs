using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;

    public float speed = 2.0f;
    public float defaultSpeed = 2.0f;
    public float sprintSpeed = 4.0f;
    public float rotateSpeed = 30.0f;

    private float horizontalInput;
    private float verticalInput;

    private bool speedInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        SpeedBoost();
        //MovePlayerWithTranslate(transform, speed); //Function / Method, they are the same thing
        //MovePlayerWithRotate(transform, rotateSpeed, speed);
    }

    private void MovePlayerWithTranslate(Transform player, float speed = 10.0f) //Function parameter
    {
        player.Translate(player.forward * speed * verticalInput * Time.deltaTime);
        player.Translate(player.right * speed * horizontalInput * Time.deltaTime);
    }

    private void MovePlayerWithRotate(Transform player, float rotateSpeed = 15.0f, float speed = 10.0f) //Function parameter
    {
        player.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        if (verticalInput > 0.01f || verticalInput < -0.01f)
        {
            player.Rotate(Vector3.up, rotateSpeed * horizontalInput * Time.deltaTime);
        }
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void SpeedBoost()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //player.Translate(player.forward * speed * 2 * verticalInput * Time.deltaTime);
            speed = sprintSpeed;
        }
        else
        {
            speed = defaultSpeed;
        }
    }
}
