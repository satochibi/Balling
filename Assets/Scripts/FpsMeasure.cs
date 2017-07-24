using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsMeasure : MonoBehaviour {

    int frameCount;
    float nextTime;

    // Use this for initialization
    void Start()
    {
        nextTime = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;

        if (Time.time >= nextTime ) {
            // 1秒経ったらFPSを表示
            this.GetComponent<Text>().text = "FPS : " + frameCount;
            frameCount = 0;
            nextTime += 1;
        }
    }
}
