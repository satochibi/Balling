using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float thrust;

    // Use this for initialization
    void Start () {
        this.GetComponent<Rigidbody>().AddForce(transform.forward * thrust);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
