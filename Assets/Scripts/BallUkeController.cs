﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallUkeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
            //Debug.Log("Ball");
        }
    }

    
}
