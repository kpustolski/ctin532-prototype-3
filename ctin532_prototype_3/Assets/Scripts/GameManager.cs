using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

    public Text thrustNum;
    public Text timeNum;
    public Text pressSpaceText;
    public Text endText;
    public float countDownNum;
    public GameObject playerObj;
    public Camera mainCamera;
    public Canvas canvas1;
    public Canvas canvas2;
    private bool arrowEnabled = true;
    private float playerVelocity=0;
    private float thrust=0;

	// Use this for initialization
	void Start () {
        canvas2.enabled = false;
        thrustNum = thrustNum.GetComponent<Text>();
        timeNum = timeNum.GetComponent<Text>();
        endText = endText.GetComponent<Text>();
        pressSpaceText = pressSpaceText.GetComponent<Text>();
        //playerObj = playerObj.GetComponent<GameObject>();
        mainCamera = mainCamera.GetComponent<Camera>();

        pressSpaceText.enabled = false;

        //canvas1 = canvas1.GetComponent<Canvas>();
        // canvas2 = canvas1.GetComponent<Canvas>();
    }
	
	// Update is called once per frame
	void Update () {
        // begin timer
        timer();
        addThrust();
        detectEndState();
    }

    void addThrust()
    {
        if(Input.GetKeyDown("up") && arrowEnabled)
        {
            thrust += 1;
            thrustNum.text = thrust.ToString();
        }

    }
    // add the timer element
    void timer()
    {
        countDownNum -= Time.deltaTime;
        timeNum.text = Mathf.Round(countDownNum).ToString();

        if (countDownNum < 0)
        {
            countDownNum = 0;
            pressSpaceText.enabled = true;
            arrowEnabled = false;
            //canvas2.enabled = true;   
            // Debug.Log("Times up!");
            //Application.LoadLevel("gameOver");
        }
    }

    void detectEndState()
    {
        playerVelocity = playerObj.GetComponent<Rigidbody>().velocity.magnitude;
        //Debug.Log(playerVelocity);
        if (canvas1.enabled == false)
        {
            if (playerVelocity > 0.0 && playerVelocity < 1.0)
            {
                mainCamera.GetComponent<CameraFollowObject>().enabled = false;
                canvas2.enabled = true;
                endText.text = playerObj.GetComponent<PlayerScript>().milestone;
            }
        }
    }

}
