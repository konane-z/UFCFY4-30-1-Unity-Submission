using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggerTransition : MonoBehaviour
{
    public Camera diggerCamera;
    public Camera mainCamera;
    public Camera miningCamera;
    public Camera outsideCamera;


    public Transform miningCameraDist;
    public Transform outsideCameraDist;

    bool diggerCameraEnabled = false;
    bool miningCameraEnabled = false;
    bool outsideCameraEnabled = false;

    public GameObject player;
    public GameObject wall;
    public GameObject exhaust;

    public Transform exhaustPos;


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
        outsideCamera.enabled = false;
    }

    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(1);
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && (diggerCameraEnabled == false))
        {
            diggerController.speed = 4;
            diggerController.sensitivity = 2;

            playerController.speed = 0;
            playerController.sensitivity = 0;
            playerController.animationSpeed = 0;

            player = GameObject.Find("digger_tom");
            //cameraController.diggerCameraToggle = true;

            mainCamera.enabled = false;
            diggerCamera.enabled = true;

            diggerCameraEnabled = true;
            Debug.Log("Semen");


        }
        if (Input.GetKeyDown(KeyCode.E) && (diggerCameraEnabled == true))
        {

            playerController.speed = 1;
            playerController.sensitivity = 2;
            playerController.animationSpeed = 1.5f;

            diggerController.speed = 0;
            diggerController.sensitivity = 0;

           

            player = GameObject.Find("char_ethan");
            //cameraController.diggerCameraToggle = false;

            mainCamera.enabled = true;
            diggerCamera.enabled = false;


            diggerCameraEnabled = false;
        }

        if (diggerCameraEnabled == true && player == GameObject.Find("digger_tom"))
        {

            float dist = Vector3.Distance(miningCameraDist.position, player.transform.position);
            float dist2 = Vector3.Distance(outsideCameraDist.position, player.transform.position);
            // print("Distance to other: " + dist);
            if (dist2 < 50)
            {
                diggerCamera.enabled = false;
                diggerCameraEnabled = false;

                miningCamera.enabled = false;
                miningCameraEnabled = false;

                outsideCamera.enabled = true;
                outsideCameraEnabled = true;
            }

            if (dist2 >= 50)
            {

                outsideCamera.enabled = false;
                outsideCameraEnabled = false;
            }

            if (dist < 20)
            {
                diggerCamera.enabled = false;
                diggerCameraEnabled = true;

                miningCamera.enabled = true;
                miningCameraEnabled = true;
            }

            {
                //print("Distance to other: " + dist);
                if (dist >= 20)
                {
                    diggerCamera.enabled = true;
                    diggerCameraEnabled = true;

                    miningCamera.enabled = false;
                    miningCameraEnabled = false;
                }

            }

            
            if (player == GameObject.Find("char_ethan"))
            {
                playerController.speed = 1;
                playerController.sensitivity = 2;
                playerController.animationSpeed = 1.5f;

                diggerController.speed = 0;
                diggerController.sensitivity = 0;

                mainCamera.enabled = true;


                diggerCamera.enabled = false;
                diggerCameraEnabled = false;

                miningCamera.enabled = false;
                miningCameraEnabled = false;
            }

            if (!mainCamera.isActiveAndEnabled)
            {
               // Instantiate(exhaust, exhaustPos.position, exhaustPos.rotation);
                
            }
            
        }
    }
}
