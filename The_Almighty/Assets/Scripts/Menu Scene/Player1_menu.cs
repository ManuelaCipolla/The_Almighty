﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1_menu : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

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
    

    void Start()
    {      
        //Spawn position
        transform.position = new Vector3(0.04f, -2.67f, 0);

        //backbutton
        Button btn = Back.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        //Boundaries of screen
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5),0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, 0);

        //movement 
        if(PlayerSettings != true)
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
        if (_PlayEnter == true && Input.GetButtonDown("Submit")) //Gameplay button
        {
            Debug.Log("Gameplay true");
            SceneManager.LoadScene("Gameplay");
        }

        if(_SettingEnter == true && Input.GetButtonDown("Submit")) //Setting button
        {
            Debug.Log("Setting true");
            PlayerSettings = true;
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
            Debug.Log("Gameplay works");
        }

        if(Collision.CompareTag("SettingButton")) //Setting button
        {
            _SettingEnter = true;
            Debug.Log("Setting works");
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

