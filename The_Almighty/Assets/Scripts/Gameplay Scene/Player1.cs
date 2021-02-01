﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    //stats
    [Header("Stats")]
    public float _speed = 5f;
    public int curHealth;
    public int maxHealth = 3;

    public int  Damage = 1;

    //Stats for fuel
    [Header("Fuel")]
    [SerializeField]
    private float _maxFuel = 100f;
    public float _currentFuel;
    [SerializeField]
    private Slider _fuelSlider;
    [SerializeField]
    private float _fuelBurnRate = 20f;

    [SerializeField]
    private float _fuelRecharge;

    //animation
        [Header("Animation")]
    public float HorizontalInput;
    public float VerticalInput;
    public SpriteRenderer theSR;
    public Animator anim;

//camShake
    public Animator camShake;

    //flip
    private bool facingRight = true;
    private Rigidbody2D rb;
    
    //on hit
    [Header("Fade on hit")]
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D triggerCollider;

        //Coins Score
    public int coinScore = 0;
    public Text CoinText;
    public int highCoin;
    public int coins;
    void Start()
    {
        coinScore = 0;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //spawning point for p1
        transform.position = new Vector3(-0.07f, -4f, 0);
        //health
        curHealth = maxHealth;
        //fuel
        _currentFuel = _maxFuel;
    }

    
    void FixedUpdate()
    {
        FuelRate();
    }

    void Update()
    {
        //Boundaries of screen 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.83f, 4.83f),0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.57f, 3.57f), transform.position.y, 0);

        Health();

        _fuelSlider.value = _currentFuel / _maxFuel;

        Flip();

    }

    void Health()
    {        
        //Health
        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if(curHealth <= 0)
        {
            Death();
        }
    }

    void FuelRate()
    {        
        if( _currentFuel > 0)
        {
            Movement();
        }

        if( _currentFuel <= 0)
        {
            Death();
        }
    }

    private void Movement()
    {
        HorizontalInput = Input.GetAxis("Horizontal1") ;
        VerticalInput = Input.GetAxis("Vertical1") ;
        
        rb.AddRelativeForce(new Vector2(HorizontalInput, VerticalInput)* _speed ,ForceMode2D.Force);

        //fuel
        if(HorizontalInput != 0 || VerticalInput != 0)
        {
            _currentFuel -= _fuelBurnRate * Time.deltaTime;
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("something smart");
            curHealth = curHealth - Damage ;
            camShake.SetTrigger("isShake");
            StartCoroutine(playerHitRoutine());
        }
        if(collision.gameObject.tag == "Fuel")
        {
            Debug.Log("Fuel up baby");
            _currentFuel = _currentFuel + _fuelRecharge;
            
            if(_currentFuel > _maxFuel)
            {
                _currentFuel = _maxFuel;
            }
        }

        if(collision.gameObject.tag == "Coins")
        {
            coinScore += 1;
            coins = PlayerPrefs.GetInt("CurrentCoins", coinScore);
            CoinText.text = "COIN " + coinScore;
        }
    }

    IEnumerator playerHitRoutine ()
    {
        triggerCollider.enabled = false;

        for (int i = 0; i < numberOfFlashes; i++)
        {
            anim.enabled = false;
            theSR.color = new Color(1f, 0.5f, 0.5f, 0.5f);
            yield return new WaitForSeconds(flashDuration);
            theSR.color = new Color(1f, 1f, 1f, 1f);
            anim.enabled = true;
            yield return new WaitForSeconds(flashDuration);
        }
        theSR.color = new Color(1f, 1f, 1f, 1f);
        triggerCollider.enabled = true;
    }

    /*public IEnumerator PlayerShield()
    {
        Debug.Log("Picked up Shield!");
        Damage= 0;
        for (int i = 0; i < numberOfFlashes; i++)
        {
            anim.enabled = false;
            theSR.color = new Color(0.5f, 0.5f, 1f, 1f);
            yield return new WaitForSeconds(flashDuration);
            theSR.color = new Color(1f, 1f, 1f, 1f);
            anim.enabled = true;
            yield return new WaitForSeconds(flashDuration);
        }
        theSR.color = new Color(1f, 1f, 1f, 1f);
        Damage = 1;
        Destroy(gameObject.GetComponent<PowerUps>());
    }*/


        void Death() //literal death (in game and real life wowa)
    {
        Debug.Log("YOU DEAD FUCKER");
        Destroy(gameObject, 1);
        SceneManager.LoadScene("Game Over");

        PlayerPrefs.SetInt("CurrentCoins", coins + coinScore);
        PlayerPrefs.Save();
    }

    void Flip()
    {
        if((HorizontalInput < 0 && facingRight) || (HorizontalInput > 0 && !facingRight))
        {
            facingRight =!facingRight;

            transform.Rotate(0, 180, 0);
        }
    }
}
