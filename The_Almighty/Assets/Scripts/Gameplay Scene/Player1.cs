using System.Collections;
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
    [Header("Currency")]
    public int coinScore;
    public Text CoinText;
    public int highCoin;
    public int coins;
    
    
    //particles
    [Header("Particles")]
    [SerializeField]
    private ParticleSystem partDead;
    [SerializeField]
    private GameObject fuelBar;
    [SerializeField]
    private ParticleSystem PuStars;
    [SerializeField]
    private ParticleSystem CoinStars;
    [SerializeField]
    private ParticleSystem FuelEffect;

    void Start()
    {
        coinScore = 0;
        highCoin = PlayerPrefs.GetInt("HighCoins");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //spawning point for p1
        transform.position = new Vector3(-0.07f, -4f, 0);
        //health
        curHealth = maxHealth;
        //fuel
        _currentFuel = _maxFuel;
        //for audio to play
        
    }

    
    void FixedUpdate()
    {
        FuelRate();
    }

    void Update()
    {
        //Boundaries of screen 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.45f, 4.55f),0);
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



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("something smart");
            curHealth = curHealth - Damage ;
            if(curHealth !=0)
            {
                if(Damage == 1)
                {
                    Debug.Log("Damage 1");
                    StartCoroutine(playerHitRoutine());
                    camShake.SetTrigger("isShake");
                }

            }
        }
        if(other.CompareTag("Fuel"))
        {
            Debug.Log("Fuel up baby");
            FuelEffect.Play();
            _currentFuel = _currentFuel + _fuelRecharge;
            
            if(_currentFuel > _maxFuel)
            {
                _currentFuel = _maxFuel;
            }
        }

        if(other.CompareTag("Coins"))
        {
            coinScore += 5;
            coins = PlayerPrefs.GetInt("CurrentCoins", coinScore);
            CoinText.text = "COIN " + coinScore;
            CoinStars.Play();
        }

        if(other.CompareTag("powerUp"))
        {
            PuStars.Play();
        }
    }

    IEnumerator playerHitRoutine ()
    {
        //triggerCollider.enabled = false;
        Damage = 0;

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
        //triggerCollider.enabled = true;
        Damage = 1;
    }

    void Death() //literal death (in game and real life wowa)
    {
        Debug.Log("YOU DEAD FUCKER");
        StartCoroutine(DeathRoutine());
        PlayerPrefs.SetInt("CurrentCoins", coins + coinScore);
        PlayerPrefs.SetInt("HighCoins", coins + coinScore + highCoin);

        
    }

    IEnumerator DeathRoutine()
    {
        theSR.color = new Color(0f, 0f, 0f, 0f);
        fuelBar.SetActive(false);
        partDead.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        SceneManager.LoadScene("Game Over");
    }

    void Flip()
    {
        if((HorizontalInput < 0 && facingRight) || (HorizontalInput > 0 && !facingRight))
        {
            facingRight =!facingRight;

            transform.Rotate(0, 180, 0);
        }
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
}
