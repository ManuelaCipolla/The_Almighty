using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Player_Test : MonoBehaviour
{

    [Header("Stats")]
    public float _speed = 5f;
    public int curHealth;
    public int maxHealth = 3;
    public int  Damage = 1;

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
    
    [Header("Animation")]
    public float HorizontalInput;
    public float VerticalInput;
    public SpriteRenderer theSR;
    public Animator anim;

    public Animator camShake;
    public ParticleSystem fire;

    private bool facingRight = true;
    
    private Rigidbody2D rb;

    [Header("Fade on hit")]
    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D triggerCollider;
    public SpriteRenderer playerSprite;

    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
    }
    void Update() 
    {

        //Boundaries of screen 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5),0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, 0);

        Health();

        //Fuel
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
    
    /*private void Movement() //Player movement
    {
        
        HorizontalInput = Input.GetAxis("Horizontal1");
        VerticalInput = Input.GetAxis("Vertical1");

        Vector3 direction = new Vector3 (HorizontalInput, VerticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        //fuel
        if(HorizontalInput != 0 || VerticalInput != 0)
        {
            _currentFuel -= _fuelBurnRate * Time.deltaTime;
        }
        CreateFire();
    }*/
    
    private void Movement() //Player movement
    {
        //better way to make this but we cannot do this
        //Vector2 direction = new Vector2(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1"));

        HorizontalInput = Input.GetAxis("Horizontal1") ;
        VerticalInput = Input.GetAxis("Vertical1") ;
        
        rb.AddRelativeForce(new Vector2(HorizontalInput, VerticalInput)* _speed ,ForceMode2D.Force);

        /*Vector2 direction = new Vector2(HorizontalInput, VerticalInput);
        Vector2 moveVelocity = direction.normalized * _speed;
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);*/

        //fuel
        if(HorizontalInput != 0 || VerticalInput != 0)
        {
            _currentFuel -= _fuelBurnRate * Time.deltaTime;
        }
        CreateJetpackParticle();
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("something smart");
            curHealth = curHealth - Damage;
            camShake.SetTrigger("isShake");
            StartCoroutine(playerHitRoutine());
            //anim.SetBool("isDmgHit",true);

            
        }
        if(collision.gameObject.tag == "Fuel")
        {
            Debug.Log("Fuel up baby");
            _currentFuel = _currentFuel + _fuelRecharge;
            _currentFuel = _maxFuel;
        }
    }
    IEnumerator playerHitRoutine ()
    {
        // int temp = 0;
        triggerCollider.enabled = false;
        // while(temp < numberOfFlashes)
        // {
        //     playerSprite.color = flashColor;
        //     yield return new WaitForSeconds(flashDuration);
        //     playerSprite.color = regularColor;
        //     yield return new WaitForSeconds(flashDuration);
        //     temp++;
        // }
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

        void Death() //literal death (in game and real life wowa)
    {
        Debug.Log("YOU DEAD FUCKER");
        Destroy(gameObject, 1);
        
        
    }

    /*void Flip()
    {
        if(!theSR.flipX && HorizontalInput < 0)
        {
            theSR.flipX = true;
        }

        else if(theSR.flipX && HorizontalInput > 0)
        {
            theSR.flipX = false;
        }
    }*/
        void Flip()
    {
        if((HorizontalInput < 0 && facingRight) || (HorizontalInput > 0 && !facingRight))
        {
            facingRight =!facingRight;

            transform.Rotate(0, 180, 0);
        }
    }
    void CreateJetpackParticle()
    {
        fire.Play();
    }
}
