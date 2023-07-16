using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggerController : MonoBehaviour
{

    Rigidbody playerBody;
    public float speed = 0f;
    public float sensitivity = 0f;


    bool walking = false;

    void Awake()
    {

    }

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
        Vector3 movement = new Vector3(sideways, 0, forward);
        movement *= speed;
        movement = transform.TransformDirection(movement);

        // Apply Force
        playerBody.AddForce(movement, ForceMode.VelocityChange);


        Camera();

        //MovementManagement(forward, walking);
    }
       
    /*void Update()
    {
            Camera();
    }
    */
        
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

    /* void MovementManagement(float forward, bool walking)
        {
        if (forward > 0)
        {
            anim.SetFloat(hash.speedFloat, animationSpeed, speedDampTime, Time.deltaTime);
        }
        else
        {
            anim.SetFloat(hash.speedFloat, 0);
        }
        
    }
    */
}

