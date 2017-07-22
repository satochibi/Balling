using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour {

    private bool isCollapse = false;

    public bool GetIsCollapse()
    {
        return this.isCollapse;
    }

    private int point;

    public int GetPoint()
    {
        if (isCollapse)
        {
            return point;
        }
        else
        {
            return 0;
        }
        
    }

    // Use this for initialization
    void Start () {
        switch (this.tag)
        {
            case "WhitePinTag":
                point = 1;
                break;
            case "BluePinTag":
                point = 5;
                break;
            case "RedPinTag":
                point = 10;
                break;
            default:
                point = 0;
                break;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        
        //倒れている判定を出すには、
        //X軸に対して60度~300度は倒れている
        //または、Z軸に対して60度~300度は倒れている
        if((30f < transform.eulerAngles.x && transform.eulerAngles.x < 360f-30f) ||
            (30f < transform.eulerAngles.z && transform.eulerAngles.z < 360f-30f))
        {
            
            //Debug.Log("倒れている");
            isCollapse = true;

        }
        else
        {
            //Debug.Log("直立");
            isCollapse = false;
        }
        
        
		
	}
}
