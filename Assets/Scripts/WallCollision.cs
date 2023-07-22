using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    public GameObject diggerArm;
    public GameObject wall;
    public GameObject debris;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        // if digger arm is on then delete block after 2 seconds and emit particles
        if (collision.gameObject.name == "digger_tom")
        {
            debris.SetActive(true);
            StartCoroutine(mineblock());
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator mineblock()
    {
        
        yield return new WaitForSeconds(2);

        wall.SetActive(false);
    }
}
