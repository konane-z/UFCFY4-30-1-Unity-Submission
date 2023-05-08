using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody playerBody;
    public float speed;
    public float sensitivity;


    private void Start()
    {
        playerBody = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Read player inputs
        float forward = Input.GetAxisRaw("Vertical");
        float sideways = Input.GetAxisRaw("Horizontal");

        // Calculate vector
        Vector3 movement = new Vector3(forward, 0, -sideways);
        movement *= speed;
        movement = transform.TransformDirection(movement);

        // Apply Force
        playerBody.AddForce(movement, ForceMode.VelocityChange);
    }

    private void Update()
    {
        Camera();
    }

    void Camera()
    {
        // Taking input from mouse left+right
        float rotation = Input.GetAxis("Mouse X");

        // Rotate player & camera based on left/right mouse movement
        if (rotation != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, rotation * sensitivity, 0f);

            playerBody.MoveRotation(playerBody.rotation * deltaRotation);
        }
    }
}
