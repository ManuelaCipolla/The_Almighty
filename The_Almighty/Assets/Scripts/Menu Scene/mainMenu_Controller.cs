using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu_Controller : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    private float HorizontalInput;
    private float VerticalInput;
    public SpriteRenderer theSR;
    private Rigidbody2D rb;


    //UI
    private bool _StoreEnter = false;
    private bool _PlayEnter = false;
    public bool _SettingEnter = false;
    private bool _ExitEnter = false;

    public bool PlayerSettings = false;

    //gameobjects
    public GameObject MainMenu;
    public GameObject Options;
    public GameObject Player1;
    Button Back;

    //HighScore
    public Text highScore;
    public Text Coins;

    [SerializeField]
    private GameObject _tutorialText;
        public StoreController StoreController;
    
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();   
        StoreController = GetComponent<StoreController>(); 
        StoreController.BackgroundValue = PlayerPrefs.GetInt("BackgroundValue");
        if(StoreController.BackgroundValue == 0)
        {
            StoreController.BackgroundValue = 1;
            PlayerPrefs.SetInt("BackgroundValue", 1);
        }
        //Spawn position
        transform.position = new Vector3(0.04f, -2.67f, 0);

        //HighScore
        highScore.text = "HIGHSCORE " + Mathf.Round(PlayerPrefs.GetFloat("highScore"));

        //backbutton
        Button btn = Back.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    void FixedUpdate() 
    {
        //movement 
        if(PlayerSettings != true)
        {
            Movement();
        }
    }
    void Update()
    {
        //Boundaries of screen
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5),0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, 0);
        
        Flip();

        Coins.text = "COINS " + PlayerPrefs.GetInt("HighCoins");
    }

        void Movement()//Player movement
    {
        HorizontalInput = Input.GetAxis("Horizontal1") ;
        VerticalInput = Input.GetAxis("Vertical1") ;
        
        rb.AddRelativeForce(new Vector2(HorizontalInput, VerticalInput)* _speed ,ForceMode2D.Force);
    }
        /*HorizontalInput = Input.GetAxis("Horizontal1");
        VerticalInput = Input.GetAxis("Vertical1");

        Vector3 direction = new Vector3 (HorizontalInput, VerticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);*/

    void Flip()
    {
        if(!theSR.flipX && HorizontalInput < 0)
        {
            theSR.flipX = true;
        }

        else if(theSR.flipX && HorizontalInput > 0)
        {
            theSR.flipX = false;
        }
    }


    void OnTriggerStay2D(Collider2D Collision) 
    { 
        
        if(Collision.CompareTag("PlayButton"))//Play Button
        {
        _tutorialText.SetActive(true);
            if(Input.GetButtonDown("Submit"))
            {
            SceneManager.LoadScene("Gameplay");
            }
        }

        if(Collision.CompareTag("SettingButton"))//Options button
        {
        _tutorialText.SetActive(true);
            if(Input.GetButtonDown("Submit"))
            {
            Options.SetActive(true);
            MainMenu.SetActive(false);
            Player1.SetActive(false);
            }
        }

        if(Collision.CompareTag("StoreButton"))//Store button
        {
        _tutorialText.SetActive(true);
            if(Input.GetButtonDown("Submit"))
            {
            SceneManager.LoadScene("Store");
            }
        } 

        if(Collision.CompareTag("ExitButton"))//Exit button
        {
        _tutorialText.SetActive(true);
            if(Input.GetButtonDown("Submit"))
            {
            QuitGame();
            Debug.Log("Exit true");
            }
        }
    } 
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("ExitButton")||(other.CompareTag("StoreButton"))||(other.CompareTag("SettingButton"))||(other.CompareTag("PlayButton")))
        {
        _tutorialText.SetActive(false);
        }
    }

        public void TaskOnClick() // Back Button
    {
        Debug.Log("it work this bad bad button");
        Options.SetActive(false);
        MainMenu.SetActive(true);
        Player1.SetActive(true);
        PlayerSettings = false;
        
    }

    public void QuitGame() // exit game
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
    
}

