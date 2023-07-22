using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggerController : MonoBehaviour
{

    Rigidbody playerBody;
    public float speed = 0f;
    public float sensitivity = 0f;


    private GameObject diggerBase;
    private GameObject diggerArm;
    public GameObject exhaust;


    public float rotation = 0f;


    bool walking = false;

    void Awake()
    {

    }

    private void Start()
    {
        playerBody = this.GetComponent<Rigidbody>();
        diggerBase = GameObject.Find("base");
        diggerArm = GameObject.Find("body_and_arm");
    }

    private void FixedUpdate()
    {
        // Read player inputs
        float forward = Input.GetAxisRaw("Vertical");
        float sideways = Input.GetAxisRaw("Horizontal");


        // Calculate vector
        Vector3 movement = new Vector3(0, 0, forward);
        movement *= speed;
        movement = transform.TransformDirection(movement);

        // Apply Force
        playerBody.AddForce(movement, ForceMode.VelocityChange);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -speed, 0f);
            diggerArm.transform.Rotate(0f, sensitivity, 0f);
            exhaust.transform.Rotate(0f, sensitivity, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, speed, 0f);
            diggerArm.transform.Rotate(0f, -sensitivity, 0f);
            exhaust.transform.Rotate(0f, -sensitivity, 0f);
        }


        //MovementManagement(forward, walking);
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

