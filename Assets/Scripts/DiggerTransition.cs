using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggerTransition : MonoBehaviour
{
    public Camera diggerCamera;
    public Camera mainCamera;
    public Camera miningCamera;

    public Transform miningCameraDist;

    bool diggerCameraEnabled = false;
    bool miningCameraEnabled = false;

    public GameObject player;
    public GameObject wall;


    [SerializeField]
    private DiggerController diggerController;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        diggerCamera.enabled = false;
        miningCamera.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.C) && (diggerCameraEnabled == false))
        {
            diggerController.speed = 4;
            diggerController.sensitivity = 2;

            playerController.speed = 0;
            playerController.sensitivity = 0;
            playerController.animationSpeed = 0;

            diggerCameraEnabled = true;

            player = GameObject.Find("digger_tom");
            //cameraController.diggerCameraToggle = true;

            mainCamera.enabled = false;
            diggerCamera.enabled = true;

        }
        if (Input.GetKey(KeyCode.V) && (diggerCameraEnabled == true))
        {
            playerController.speed = 1;
            playerController.sensitivity = 2;
            playerController.animationSpeed = 1.5f;

            diggerController.speed = 0;
            diggerController.sensitivity = 0;

            diggerCameraEnabled = false;

            player = GameObject.Find("char_ethan");
            //cameraController.diggerCameraToggle = false;

            mainCamera.enabled = true;
            diggerCamera.enabled = false;
        }

        if (diggerCameraEnabled == true)
        {
            float dist = Vector3.Distance(miningCameraDist.position, player.transform.position);
            print("Distance to other: " + dist);
            if (dist < 20)
            {
                diggerCamera.enabled = false;
                diggerCameraEnabled = false;

                miningCamera.enabled = true;
                miningCameraEnabled = true;
            }
        }
        if (miningCameraEnabled == true) 
        {
            float dist = Vector3.Distance(miningCameraDist.position, player.transform.position);
            print("Distance to other: " + dist);
            if (dist >= 20)
            {
                diggerCamera.enabled = true;
                diggerCameraEnabled = true;

                miningCamera.enabled = false;
                miningCameraEnabled = false;
            }
        }
    }
}
