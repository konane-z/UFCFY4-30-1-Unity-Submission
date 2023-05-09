using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public GameObject target;

    // Looks at results of last frame
    private void LateUpdate()
    {
        transform.LookAt(target.transform);
    }
}
