using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    //stats
    public float _speed = 5f;
    public int curHealth;
    public int maxHealth = 3;

    public int  Damage = 1;

    //Stats for fuel
    [SerializeField]
    private float _maxFuel = 100f;
    public float _currentFuel;
    [SerializeField]
    private Slider _fuelSlider;
    [SerializeField]
    private float _fuelBurnRate = 20f;

    [SerializeField]
    private float _fuelRecharge;

    private Rigidbody2D rb;
    
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //spawning point for p1
        transform.position = new Vector3(-2, -3.5f, 0);
        //health
        curHealth = maxHealth;
        //fuel
        _currentFuel = _maxFuel;
    }

    
    void FixedUpdate()
    {
        FuelRate();
        //Fuel
        _fuelSlider.value = _currentFuel / _maxFuel;
        
    }

    void Update()
    {
        //Boundaries of screen 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5),0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, 0);

        Health();
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
    private void Movement() //Player movement
    {
        
        float HorizontalInput = Input.GetAxis("Horizontal1");
        float VerticalInput = Input.GetAxis("Vertical1");

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
        }
        if(collision.gameObject.tag == "Fuel")
        {
            Debug.Log("Fuel up baby");
            _currentFuel = _currentFuel + _fuelRecharge;
            _currentFuel = _maxFuel;
        }
    }

        void Death() //literal death (in game and real life wowa)
    {
        Debug.Log("YOU DEAD FUCKER");
        Destroy(gameObject, 1);
        SceneManager.LoadScene("Game Over");
        
    }
}
