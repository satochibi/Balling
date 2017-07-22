using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallController : MonoBehaviour {

    public float thrust;


    private Vector3 initPos;
    private Vector3 initAng;

    public bool isUseAcceleration = true;

    // Use this for initialization
    void Start () {
        initPos = this.transform.position;
        initAng = this.transform.eulerAngles;
        //this.GetComponent<Rigidbody>().AddForce(transform.forward * thrust);
    }
	
	// Update is called once per frame
	void Update () {
        
        Vector3 value = new Vector3(Input.acceleration.x, 0, Input.acceleration.y);
        //transform.position += value.normalized * 0.1f;

        if (isUseAcceleration)
        {
            this.GetComponent<Rigidbody>().AddForce(value.normalized * thrust);

        }
        else
        {
            //if (this.GetComponent<Rigidbody>().velocity.magnitude <= 0.2f)
            //{
            //    NextBall();
            //}
        }

        //Debug.Log(this.GetComponent<Rigidbody>().velocity.magnitude);
    }



    public void NextBall()
    {
        PinDestroy();
        Respawn();

    }


    private void PinDestroy()
    {
        GameObject[] whitePins = GameObject.FindGameObjectsWithTag("WhitePinTag");
        GameObject[] bluePins = GameObject.FindGameObjectsWithTag("BluePinTag");
        GameObject[] redPins = GameObject.FindGameObjectsWithTag("RedPinTag");


        //白に対して、
        foreach (GameObject whitePin in whitePins)
        {

            //倒れていたら
            if (whitePin.GetComponent<PinController>().GetIsCollapse())
            {
                Destroy(whitePin);
            }

        }

        //青に対して、
        foreach (GameObject bluePin in bluePins)
        {

            //倒れていたら
            if (bluePin.GetComponent<PinController>().GetIsCollapse())
            {
                Destroy(bluePin);
            }

        }

        //赤に対して、
        foreach (GameObject redPin in redPins)
        {

            //倒れていたら
            if (redPin.GetComponent<PinController>().GetIsCollapse())
            {
                Destroy(redPin);
            }

        }
    }

    private void Respawn()
    {
        this.transform.position = this.initPos;
        this.transform.eulerAngles = this.initAng;
        this.isUseAcceleration = true;
    }

}
