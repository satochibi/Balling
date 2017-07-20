using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallController : MonoBehaviour {

    public float thrust;


    private Vector3 initPos;
    private Vector3 initAng;

    // Use this for initialization
    void Start () {
        initPos = this.transform.position;
        initAng = this.transform.eulerAngles;
        //this.GetComponent<Rigidbody>().AddForce(transform.forward * thrust);
    }
	
	// Update is called once per frame
	void Update () {
        
        Vector3 value = new Vector3(Input.acceleration.x, 0, Input.acceleration.y);
        //transform.position += new Vector3();

        this.GetComponent<Rigidbody>().AddForce(value.normalized * thrust);
        
    }


    

    public void PinDestroy()
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

    public void Respawn()
    {
        this.transform.position = this.initPos;
        this.transform.eulerAngles = this.initAng;
    }

}
