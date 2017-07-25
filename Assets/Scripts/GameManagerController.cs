using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour {

    public GameObject ballPrefab;
    private int turn = 1;
    private float totalScore = 0;
    private float speedThreshold = 0.08f;

    // Use this for initialization
    void Start () {
        BallRespawn();
    }

    void Awake()
    {
        Application.targetFrameRate = 60; //60FPSに設定
    }

    // Update is called once per frame
    void Update()
    {

        GameObject ball = GameObject.FindGameObjectWithTag("Ball");

        //次の投球へ
        if (ball != null)
        {
            if (OverAllSpeed() <= speedThreshold && ball.GetComponent<BallController>().isUseAcceleration == false)
            {
                Destroy(ball);
                NextBall();
            }

        }
        else
        {
            if (OverAllSpeed() <= speedThreshold)
            {
                NextBall();
            }
        }


        //Debug.Log("speed: " + OverAllSpeed() + " score: "+ this.totalScore);


    }

    public float GetTotalScore()
    {
        return this.totalScore;
    }

    public int GetTurn()
    {
        return this.turn;
    }

    private void NextBall()
    {
        this.totalScore += PinDestroy();
        BallRespawn();
        turn++;

    }

    private void BallRespawn()
    {
        Instantiate(ballPrefab, new Vector3(0,0.21f,-3.5f), Quaternion.identity);
    }

    //全体の速度
    private float OverAllSpeed()
    {
        GameObject[] whitePins = GameObject.FindGameObjectsWithTag("WhitePinTag");
        GameObject[] bluePins = GameObject.FindGameObjectsWithTag("BluePinTag");
        GameObject[] redPins = GameObject.FindGameObjectsWithTag("RedPinTag");

        GameObject ball = GameObject.FindGameObjectWithTag("Ball");

        float speed = 0;

        foreach (GameObject whitePin in whitePins)
        {
            speed += whitePin.GetComponent<Rigidbody>().velocity.magnitude;
        }
        foreach (GameObject bluePin in bluePins)
        {
            speed += bluePin.GetComponent<Rigidbody>().velocity.magnitude;
        }
        foreach (GameObject redPin in redPins)
        {
            speed += redPin.GetComponent<Rigidbody>().velocity.magnitude;
        }

        if (ball != null)
        {
            speed += ball.GetComponent<Rigidbody>().velocity.magnitude;
        }

        return speed;
    }



    private float PinDestroy()
    {
        GameObject[] whitePins = GameObject.FindGameObjectsWithTag("WhitePinTag");
        GameObject[] bluePins = GameObject.FindGameObjectsWithTag("BluePinTag");
        GameObject[] redPins = GameObject.FindGameObjectsWithTag("RedPinTag");

        float score = 0;

        //白に対して、
        foreach (GameObject whitePin in whitePins)
        {
            score += whitePin.GetComponent<PinController>().GetPoint();

            //倒れていたら
            if (whitePin.GetComponent<PinController>().GetIsCollapse())
            {
                Destroy(whitePin);
            }

        }

        //青に対して、
        foreach (GameObject bluePin in bluePins)
        {
            score += bluePin.GetComponent<PinController>().GetPoint();

            //倒れていたら
            if (bluePin.GetComponent<PinController>().GetIsCollapse())
            {
                Destroy(bluePin);
            }

        }

        //赤に対して、
        foreach (GameObject redPin in redPins)
        {
            score += redPin.GetComponent<PinController>().GetPoint();

            //倒れていたら
            if (redPin.GetComponent<PinController>().GetIsCollapse())
            {
                Destroy(redPin);
            }

        }

        return score / this.turn;
    }
}
