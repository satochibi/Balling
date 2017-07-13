using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour {

    public bool isCollapse = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        //倒れている判定を出すには、
        //X軸に対して60度~300度は倒れている
        //または、Z軸に対して60度~300度は倒れている
        if((60f < transform.eulerAngles.x && transform.eulerAngles.x < 300f) ||
            (60f < transform.eulerAngles.z && transform.eulerAngles.z < 300f))
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
