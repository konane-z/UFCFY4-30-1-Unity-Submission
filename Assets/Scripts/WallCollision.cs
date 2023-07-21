using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    public GameObject diggerArm;
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("Collision");
        wall.SetActive(false);
        /*
        // if digger arm is on then delete block after 2 seconds and emit particles
        if (collision.gameObject.name == "cutting_wheel")
        {
            Debug.Log("Collision");
            wall.active = false;

        }
        */
    }


    // Update is called once per frame
    void Update()
    {

    }
}
