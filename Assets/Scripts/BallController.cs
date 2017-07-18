using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallState
{
    Stop,Force,Going,End
}

public class BallController : MonoBehaviour {

    public float thrust;

    public BallState state;

    private Vector3 initPos;
    private Vector3 initAng;

    // Use this for initialization
    void Start () {
        initPos = this.transform.position;
        initAng = this.transform.eulerAngles;
    }
	
	// Update is called once per frame
	void Update () {


        switch (state)
        {
            case BallState.Stop:
                this.GetComponent<Rigidbody>().isKinematic = true;
                break;
            case BallState.Force:
                this.GetComponent<Rigidbody>().isKinematic = false;
                this.GetComponent<Rigidbody>().AddForce(transform.forward * thrust);
                this.state = BallState.Going;
                break;
            case BallState.Going:
                if (this.GetComponent<Rigidbody>().velocity.magnitude <= 0.03f)
                {
                    this.state = BallState.End;
                }
                break;
            case BallState.End:
                this.PinDestroy();
                this.Respawn();
                this.state = BallState.Stop;
                break;
                
        }

        Debug.Log(state);
        
        
	}


    public void SetAngleLeft()
    {
        if (this.state == BallState.Stop)
        {
            transform.eulerAngles =
            new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y - 0.1f,
            transform.eulerAngles.z
            );
        }
    }

    public void SetAngleRight()
    {
        if (this.state == BallState.Stop)
        {
            transform.eulerAngles =
            new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y + 0.1f,
            transform.eulerAngles.z
            );
        }
    }

    public void SetBallGo()
    {
        if (this.state == BallState.Stop)
        {
            this.state = BallState.Force;

        }
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
