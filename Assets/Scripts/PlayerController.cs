using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerBody;
    public float speed = 1.0f;
    public float sensitivity = 2.0f;

    public float animationSpeed = 1.5f;
    public float speedDampTime = 0.01f;

    private Animator anim;
    private HashIDs hash;
    bool walking = false;

    public GameObject digger;

    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(1, 1f);

        // Import the HashID script attached to any objects with tag 'GameController'
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();

    }

    private void Start()
    {
        playerBody = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.C))
        {
            transform.position = new Vector3(0f, 100f, 0f);
        }

        if (Input.GetKey(KeyCode.V))
        {
            digger = GameObject.Find("digger_tom");
            transform.position = new Vector3(digger.transform.position.x, digger.transform.position.y + 2, digger.transform.position.z - 3);

        }
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

        MovementManagement(forward, walking);
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

    void MovementManagement(float forward, bool walking)
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
    
}

