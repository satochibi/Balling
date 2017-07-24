using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClearTextController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] whitePins = GameObject.FindGameObjectsWithTag("WhitePinTag");
        GameObject[] bluePins = GameObject.FindGameObjectsWithTag("BluePinTag");
        GameObject[] redPins = GameObject.FindGameObjectsWithTag("RedPinTag");

        if (whitePins.Length==0 && bluePins.Length == 0 && redPins.Length == 0)
        {
            this.GetComponent<Text>().text = "Clear!!";
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("GameScene");

            }
        }
    }
}
