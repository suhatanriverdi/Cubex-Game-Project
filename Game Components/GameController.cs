//Büşra Nur Bahadır 201511006
//Süha Tanrıverdi 201611689

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public static GameController instance;
    // Joystick Off-The-Shelf Library, We need to initialize it then customize
    protected Joystick joystick;
    protected JoyButton joybutton;
    // Ground Variable to check if Player on the ground
    bool grounded = true;

    // Smoother Acceleration for Player Movement
    private int speed = 10;

    // Player Game Object for WASD controllers
    public GameObject player;
    Rigidbody p_Rigidbody;
    private bool isGameOver = false; //boolean for game status
    Vector3 direction;
    public int gameScore;
    public Text scoreText;
    public Text gameTime; //public Text gameOver;
    private float time;
    public Hashtable data;

    //to Save player data call SaveSystem class
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(data);
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


    //Start Count down of the timer
    void StartCoundownTimer()
    {
        if (gameTime != null)
        {
            time = 120;//2 minute
            gameTime.text = "Time Left: 2:00:000"; //set initial string to two minutes
            InvokeRepeating("UpdateTimer", 0.0f, 0.01f); //Invokes the method UpdateTimer in time seconds, then repeatedly every repeatRate seconds.
        }
    }


    void UpdateTimer()
    {
        //when gameTime is exists and Game is not over 
        //update time text on the screen 
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
        direction=new Vector3((joystick.Horizontal * (-6f) + joystick.Vertical * -6f), p_Rigidbody.velocity.y, (joystick.Horizontal * 6f + joystick.Vertical * -6f));
        p_Rigidbody.AddForce(direction *4 * Time.fixedDeltaTime, ForceMode.VelocityChange); 
    }


    // Update is called once per frame
    void Update()
    {
        //when time is up Over the Game and go to Game Over Menu
        if (time < 0)
        {
            gameTime.text = "Time Left:00:00:000";
            isGameOver = true;
            SceneManager.LoadScene("GameOverMenu");

        }

        //to fix player's y dimention
        if (joybutton.Pressed && grounded)
        {
            // We actually locked the movement for player in Y axis but only jump movement allowed here!
            p_Rigidbody.velocity += new Vector3(0, 2f, 0);//Jump
        }
        //update game score's test
        scoreText.text = "" + gameScore;

        // Player(Cube) Controler, with WASD keys for Desktop Build
        if (Input.GetKey(KeyCode.W))
        {   // Move to -X Coordinates
            //player.transform.position += new Vector3(-0.2f, 0, 0);
            p_Rigidbody.velocity += new Vector3(-1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {   // Move to +X Coordinates
            //player.transform.position += new Vector3(0.2f, 0, 0);
            p_Rigidbody.velocity += new Vector3(1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {   // Move to -Z Coordinates
            //player.transform.position += new Vector3(0, 0, -0.2f);
            p_Rigidbody.velocity += new Vector3(0, 0, -1f);
        }
        if (Input.GetKey(KeyCode.D))
        {   // Move to +Z Coordinates
            //player.transform.position += new Vector3(0, 0, 0.2f);
            p_Rigidbody.velocity += new Vector3(0, 0, 1f);
        }
        if (Input.GetKey(KeyCode.Space) && grounded)
        {   // Move to +Y Coordinates (JUMP)
            //player.transform.position += new Vector3(0, 0.1f, 0);
            p_Rigidbody.velocity += new Vector3(0, 2.1f, 0);
        }
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
        //when player reached finish point save player data and level up
        if (collidedWith.tag == "Finish")
        {
            if (SceneManager.GetActiveScene().name != "level_1")
                data = SaveSystem.DataLoader();
            else
                data = new Hashtable();

            if (data.ContainsKey(SceneManager.GetActiveScene().name))
                data[SceneManager.GetActiveScene().name] = gameScore;
            else
            data.Add(SceneManager.GetActiveScene().name,gameScore);
            SavePlayer();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }

        //Update game score
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