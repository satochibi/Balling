using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallController : MonoBehaviour
{

    public float thrust;
    public bool isUseAcceleration = true;


    // Update is called once per frame
    void Update()
    {

        Vector3 value = new Vector3(Input.acceleration.x, 0, Input.acceleration.y);

        if (isUseAcceleration)
        {
            this.GetComponent<Rigidbody>().AddForce(value.normalized * thrust);
        }
        // this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 10));


    }
}
