using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggerTransition : MonoBehaviour
{
    bool diggerCamera = false;

    public GameObject player; 


    [SerializeField]
    private DiggerController diggerController;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C) && (diggerCamera == false))
        {
            diggerController.speed = 1;
            diggerController.sensitivity = 2;
            
            playerController.speed = 0;
            playerController.sensitivity = 0;
            playerController.animationSpeed = 0;
            
            diggerCamera = true;

            cameraController.diggerCameraToggle = true;

        }
        if (Input.GetKey(KeyCode.V) && (diggerCamera == true))
        {
            playerController.speed = 1;
            playerController.sensitivity = 2;
            playerController.animationSpeed = 1.5f;

            diggerController.speed = 0;
            diggerController.sensitivity = 0;

            diggerCamera = false;

            cameraController.diggerCameraToggle = false;
        }
    }
}
