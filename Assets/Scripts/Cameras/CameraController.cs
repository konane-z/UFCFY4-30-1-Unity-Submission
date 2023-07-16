using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;

   // public float cameraX = 0.0f;
    public float cameraY = 0.0f;
    //public float cameraZ = 0.0f;

    public float cameraRotX = 0.0f;
    public float cameraRotY = 0.0f;
    public float cameraRotZ = 0.0f;

    public float rotSensitivity = 10f;
    public float panSensitivity = 0.1f;

    public bool diggerCameraToggle = false;

    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    // Looks at results of last frame
    private void LateUpdate()
    {
        if (diggerCameraToggle == false)
        {
            float desiredAngle = target.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(cameraRotX, desiredAngle, cameraRotZ);
            transform.position = target.transform.position + (rotation * offset);
            transform.LookAt(target.transform);
            transform.position = transform.position + new Vector3(0, cameraY, 0);
        }
        if (diggerCameraToggle == true)
        {
            transform.LookAt(target.transform);
        }
        }

    
    private void FixedUpdate()
    {
        if (diggerCameraToggle == false)
        {
            target = GameObject.Find("char_ethan_cameraAnchor");
            float lookY = Input.GetAxisRaw("Mouse Y");
            cameraRotX = cameraRotX + (lookY * -rotSensitivity);
            cameraY = cameraY + (lookY * panSensitivity);
            cameraRotX = Mathf.Clamp(cameraRotX, -50.0f, 50.0f);
            cameraY = Mathf.Clamp(cameraY, -0.5f, 0.5f);
        }
        if (diggerCameraToggle == true)
        {
            target = GameObject.Find ("digger_tom");
        }

    }
    
}
