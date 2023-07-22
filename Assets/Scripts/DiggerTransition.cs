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
    public GameObject diggerLight;

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
        if (Input.GetKey(KeyCode.C) && (diggerCameraEnabled == false))
        {
            diggerController.speed = 6;
            diggerController.sensitivity = 1;

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
            playerController.speed = 2;
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

        if (diggerCameraEnabled == true && player == GameObject.Find("digger_tom"))
        {

            float dist = Vector3.Distance(miningCameraDist.position, player.transform.position);
            float dist2 = Vector3.Distance(outsideCameraDist.position, player.transform.position);
            //print("Distance to other: " + dist2);
            if (dist2 < 80)
            {
                diggerCamera.enabled = false;
                diggerCameraEnabled = true;

                miningCamera.enabled = false;
                miningCameraEnabled = false;

                outsideCamera.enabled = true;
                outsideCameraEnabled = true;

                diggerLight.SetActive(false);
            }

            if (dist2 >= 80)
            {

                outsideCamera.enabled = false;
                outsideCameraEnabled = false;

            }

            if (dist < 20 && outsideCameraEnabled == false)
            {
                diggerCamera.enabled = false;
                diggerCameraEnabled = true;

                miningCamera.enabled = true;
                miningCameraEnabled = true;
            }

            {
                //print("Distance to other: " + dist);
                if (dist >= 200)
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
