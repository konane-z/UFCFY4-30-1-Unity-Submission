using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour
{

    public float armY = 0f;
    public float armX = 0f;
    public float maxX = 0f;
    public GameObject diggerBlade;

    // Start is called before the first frame update
    void Start()
    {
        diggerBlade = GameObject.Find("arm");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Keypad4))
        {
            armY = -1;
            transform.Rotate(0f, armY, 0f);

        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            armY = +1;
            transform.Rotate(0f, armY, 0f);
        }

        if (Input.GetKey(KeyCode.Keypad8))
        {
            maxX = maxX + 1;
            maxX = Mathf.Clamp(maxX, -20, 65);

            if (maxX < 65)
            {
                diggerBlade.transform.Rotate(-1, 0f, 0f);
            }

        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            maxX = maxX - 1;
            maxX = Mathf.Clamp(maxX, -20, 65);

            if (maxX > -20)
            {
                diggerBlade.transform.Rotate(1, 0f, 0f);
            }
        }

    }
}
