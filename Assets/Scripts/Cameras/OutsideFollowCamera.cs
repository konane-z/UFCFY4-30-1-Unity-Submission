using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideFollowCamera : MonoBehaviour
{

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(target.transform);
    }
}
