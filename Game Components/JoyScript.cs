using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyScript : MonoBehaviour {
    protected Joystick joystick;
    protected JoyButton joybutton;
    bool grounded = true;

    private int timeleft = 15; // TIMELEFT
    public Text MyText;
    //public Text gameOver;

    public void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Ground")) { grounded = true; }
    }

    public void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) { grounded = false; }
    }

    // Use this for initialization
    void Start() {
        MyText.text = "";
        InvokeRepeating("decreaseTimeSec", 1.0f, 1.0f); // Call Every Seconds
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
    }

    // Update is called once per frame
    void Update() {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3((joystick.Horizontal * (-9f) + joystick.Vertical * -9f), rigidbody.velocity.y, (joystick.Horizontal * 9f + joystick.Vertical * -9f));
        if(joybutton.Pressed && grounded) {
            rigidbody.velocity += Vector3.up * 9f;
        }
    }

    void decreaseTimeSec() {
        // Decrease Time
        if (timeleft > 0) {
            timeleft -= 1;
            MyText.text = "" + timeleft;
        }
        //else {
           // gameOver.text = "GAME OVER!";
        //}
    }
}