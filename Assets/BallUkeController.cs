using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallUkeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            
            
            GameObject ball = GameObject.FindGameObjectWithTag("Ball");
            if (ball.GetComponent<BallController>().state == BallState.Going)
            {
                ball.GetComponent<BallController>().state = BallState.End;
            }
            

            
        }
    }
}
