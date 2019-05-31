//Süha Tanrıverdi 201611689

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour {

    protected Joystick joystick;
    protected JoyButton joybutton;

    // Use this for initialization
    void Start () {

        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
    }
	
	// Update is called once per frame
	void Update () {

        var rigidbody = GetComponent<Rigidbody>();
  
        rigidbody.velocity = new Vector3((joystick.Horizontal * (8f) + joystick.Vertical * 8f), rigidbody.velocity.y, (joystick.Horizontal * -8f + joystick.Vertical * 8f));
	}
}