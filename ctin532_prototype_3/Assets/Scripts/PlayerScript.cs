using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour {


    public Text thrustNumber;
    public Canvas canvas1;
    public Text pressSpaceText;
    public string milestone;

    private float v = 0;
    private bool spacePressedOnce = false;

    public AudioClip coinSound;
    public AudioClip elephantSound;
    AudioSource audio;


    //https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html
    public float thrust=0;
    public Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        thrustNumber = thrustNumber.GetComponent<Text>();
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        // convert score text to int
        int t = Convert.ToInt32(thrustNumber.text);

        thrust = t*100;

        if (pressSpaceText.enabled)
        {

            if (Input.GetKeyDown("space") && !spacePressedOnce)
            {
                canvas1.enabled = false;
                rb.AddForce(transform.up * thrust);
                spacePressedOnce = true;
                audio.PlayOneShot(elephantSound, 0.7F);

            }
        }
       // v = GetComponent<Rigidbody>().velocity.magnitude;
       // Debug.Log(v);
    }

    void OnTriggerEnter(Collider other)
    {
        audio.PlayOneShot(coinSound, 0.7F);
        switch (other.tag)
        {
            case "clouds":
                milestone = "Congrats! You've reached the clouds!";
                break;
            case "airplane":
                milestone = "Congrats! You've reached airplanes!";
                break;
            case "atmosphere":
                milestone = "Congrats! You've reached the edge of the atmosphere!";
                break;
            case "spaceStation":
                milestone = "Congrats! You've reached the Space Station!";
                break;
            case "moon":
                milestone = "Congrats! You've reached the Moon!";
                break;
            case "mars":
                milestone = "Congrats! You've reached mars!";
                break;
            case "aliens":
                milestone = "Congrats! You've made contact with aliens!";
                break;
            case "anotherDimention":
                milestone = "Congrats! You've reached another dimention!";
                break;
            default:
                milestone = "You need more thrust! Try again.";
                break;

        }
    }

}
