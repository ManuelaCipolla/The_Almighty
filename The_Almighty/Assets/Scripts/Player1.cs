using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    //stats
    [SerializeField]
    private float _speed = 5f;
    public int curHealth;
    public int maxHealth = 3;

    //Stats for fuel
    [SerializeField]
    private float _maxFuel = 100f;
    public float _currentFuel;
    [SerializeField]
    private Slider _fuelSlider;
    [SerializeField]
    private float _fuelBurnRate = 20f;
    
    void Start()
    {
        //spawning point for p1
        transform.position = new Vector3(-2, -3.5f, 0);
        //health
        curHealth = maxHealth;
        //fuel
        _currentFuel = _maxFuel;
    }

    
    void Update()
    {
        FuelRate();

        //Boundaries of screen 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5),0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, 0);

        Health();

        //Fuel
        _fuelSlider.value = _currentFuel / _maxFuel;
        
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
    void Movement() //Player movement
    {
        
        float HorizontalInput = Input.GetAxis("Horizontal1");
        float VerticalInput = Input.GetAxis("Vertical1");

        Vector3 direction = new Vector3 (HorizontalInput, VerticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

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
            curHealth --;
        }
    }

        void Death() //literal death (in game and real life wowa)
    {
        Debug.Log("YOU DEAD FUCKER");
        Destroy(gameObject, 1);
        SceneManager.LoadScene("Game Over");
        //Application.LoadLevel(Application.loadedLevel);  [Application does not contain a definition for loadLevel]
    }
}
