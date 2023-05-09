using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCamera : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    // Looks at results of last frame
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        transform.position = desiredPosition;
        transform.LookAt(target.transform.position);
    }
}
