using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    protected Joystick joystick;
    protected JoyButton joybutton;
    bool grounded = true;
    Rigidbody p_Rigidbody;
    private bool isGameOver = false;
    Vector3 direction;
    public int gameScore;
    public Text scoreText;
    public Text gameTime; //public Text gameOver;
    private float time;
    public Hashtable score;
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }    
  
    // Use this for initialization
    void Start()
    {
      
            if (instance == null)
            {
                instance = this;

            }
            else if (instance != this)
            {
                Debug.Log("the singletance ");
            }
        scoreText.text = "";
        p_Rigidbody = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
        StartCoundownTimer();
       

    }
    void StartCoundownTimer()
    {
        if (gameTime != null)
        {
            time =120;//2 minute
            gameTime.text = "Time Left: 5:00:000";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01f);
        }
    }
    void UpdateTimer()
    {
        if (gameTime != null && !isGameOver)
        {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            string fraction = ((time * 100) % 100).ToString("000");
            gameTime.text = "Time Left: " + minutes + ":" + seconds + ":" + fraction;
        }
    }
  
    public void FixedUpdate()
    {
      
        direction=new Vector3((joystick.Horizontal * (-4f) + joystick.Vertical * -4f), p_Rigidbody.velocity.y, (joystick.Horizontal * 4f + joystick.Vertical * -4f));
        p_Rigidbody.AddForce(direction *4 * Time.fixedDeltaTime, ForceMode.VelocityChange); 
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 0)
        {
            gameTime.text = "Time Left:00:00:000";
            isGameOver = true;
            SceneManager.LoadScene("GameOverMenu");

        }

        if (joybutton.Pressed && grounded)
        {
            p_Rigidbody.velocity = transform.TransformDirection(p_Rigidbody.velocity.x, p_Rigidbody.velocity.y-2, p_Rigidbody.velocity.z+2);//Jump
        }
        scoreText.text = "" + gameScore;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { grounded = true; }
      
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { grounded = false; }
    }

    void OnTriggerEnter(Collider collidedWith)
    {

        if (collidedWith.tag == "Finish")
        {
            //PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, gameScore);
            
               SavePlayer();
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
        if (collidedWith.tag == "Point")
        {
            gameScore++;
        }

        if (collidedWith.tag == "diamond")
        {
            gameScore += 2;
        }
    }

}