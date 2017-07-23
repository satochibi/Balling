using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //ピンを探す
        GameObject[] whitePins = GameObject.FindGameObjectsWithTag("WhitePinTag");
        GameObject[] bluePins = GameObject.FindGameObjectsWithTag("BluePinTag");
        GameObject[] redPins = GameObject.FindGameObjectsWithTag("RedPinTag");

        int score = 0;
        int whiteFallingPinCount = 0;
        int blueFallingPinCount = 0;
        int redFallingPinCount = 0;
        
        //白に対して、
        foreach (GameObject whitePin in whitePins)
        {
            score += whitePin.GetComponent<PinController>().GetPoint();

            //倒れていたら
            if (whitePin.GetComponent<PinController>().GetIsCollapse())
            {
                //倒れているピンを数える
                whiteFallingPinCount++;
            }
            
        }

        //青に対して、
        foreach (GameObject bluePin in bluePins)
        {
            score += bluePin.GetComponent<PinController>().GetPoint();

            //倒れていたら
            if (bluePin.GetComponent<PinController>().GetIsCollapse())
            {
                //倒れているピンを数える
                blueFallingPinCount++;
            }

        }

        //赤に対して、
        foreach (GameObject redPin in redPins)
        {
            score += redPin.GetComponent<PinController>().GetPoint();

            //倒れていたら
            if (redPin.GetComponent<PinController>().GetIsCollapse())
            {
                //倒れているピンを数える
                redFallingPinCount++;
            }

        }


        //ポイントを表示
        this.GetComponent<Text>().text =
            "R: " + redFallingPinCount + "/" + redPins.Length + "\n" +
            "B: " + blueFallingPinCount + "/" + bluePins.Length + "\n" +
            "W: " + whiteFallingPinCount + "/" + whitePins.Length + "\n" +
            "Score: " + score + "\n" +
            "TotalScore:" + GameObject.Find("GameManager").GetComponent<GameManagerController>().GetTotalScore();
	}
}
