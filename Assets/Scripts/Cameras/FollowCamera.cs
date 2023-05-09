using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;

   // public float cameraX = 0.0f;
    public float cameraY = 0.0f;
    //public float cameraZ = 0.0f;

    public float cameraRotX = 0.0f;
    public float cameraRotY = 0.0f;
    public float cameraRotZ = 0.0f;

    public float rotSensitivity = 0.25f;
    public float panSensitivity = 0.25f;

    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    // Looks at results of last frame
    private void LateUpdate()
    {
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(cameraRotX, desiredAngle, cameraRotZ);
        transform.position = target.transform.position + (rotation * offset);
        transform.LookAt(target.transform);
        transform.position = transform.position + new Vector3(0, cameraY, 0);
    }

    
    private void FixedUpdate()
    {
        float lookY = Input.GetAxisRaw("Mouse Y");
        cameraRotX = cameraRotX + (lookY * -rotSensitivity);
        cameraY = cameraY + (lookY * panSensitivity);
        cameraRotX = Mathf.Clamp(cameraRotX, -50.0f, 50.0f);
        cameraY = Mathf.Clamp(cameraY, -0.5f, 0.5f);

    }
    
}
