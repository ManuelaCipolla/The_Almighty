using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1_menu : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    //UI
    private bool _StoreEnter = false;
    private bool _PlayEnter = false;
    public bool _SettingEnter = false;
    private bool _ExitEnter = false;

    //gameobjects
    public GameObject MainMenu;
    public GameObject Options;
    public GameObject Player1;

    

    void Start()
    {
        transform.position = new Vector3(-2, -3.5f, 0);
    }

    void Update()
    {
        //Boundaries of screen
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5),0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, 0);

        if(_SettingEnter != true)
        {
            Movement();
        }

        UIButtons();
    }

        private void Movement() //Player movement
    {
        float HorizontalInput = Input.GetAxis("Horizontal1");
        float VerticalInput = Input.GetAxis("Vertical1");

        Vector3 direction = new Vector3 (HorizontalInput, VerticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void UIButtons ()
    {
        //PlayButton it needs to check it per frame if player enter is true.
        if (_PlayEnter == true && Input.GetButtonDown("Submit"))
        {
            Debug.Log("It works");
            SceneManager.LoadScene("Gameplay");
        }

        if(_SettingEnter == true && Input.GetButtonDown("Submit")) //Setting button
        {
            Debug.Log("Setting true");
            Options.SetActive(true);
            MainMenu.SetActive(false);
            Player1.SetActive(false);
        }

        if(_StoreEnter == true && Input.GetButtonDown("Submit")) //Store button
        {
            Debug.Log("Store true");
            SceneManager.LoadScene("Store");
        }

        if(_ExitEnter == true && Input.GetButtonDown("Submit")) //Exit button
        {
            QuitGame();
            Debug.Log("Exit true");
        }
    }

    void OnTriggerEnter2D(Collider2D Collision) 
    { 
        
        if(Collision.CompareTag("PlayButton"))//Play Button
        {
            _PlayEnter = true;
            Debug.Log("yay");
        }

        if(Collision.CompareTag("SettingButton")) //Setting button
        {
            _SettingEnter = true;
            Debug.Log("Setting works");
        }

        if(Collision.CompareTag("ExitButton"))
        {
            _ExitEnter = true;
            Debug.Log("Exit works");
        }

        if(Collision.CompareTag("StoreButton")) //Store button
        {
            _StoreEnter = true;
            Debug.Log("Store works");
        } 

        if(Collision.CompareTag("ExitButton")) //Exit button
        {
            _ExitEnter = true;
            Debug.Log("Exit works");
        }
    } 

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
    
}

