using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //Powerups
    public float multiplier = 2f;
    public float duration = 10f;
    public GameObject pickupEffect;
    //public GameObject Shield;
    public GameObject instance;

    //public bool IsPickupActive = false;

    //Spawning / movement
    private float rotationSpeed;
    private Rigidbody2D rb;
    [SerializeField]
    private float _speed;
    private Vector2 direction;
    private targetPoint target;
    private float shift;

    void Start()
{
        //spawning
        rotationSpeed = Random.Range(-25,25);
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<targetPoint>();
        direction = target.transform.position - transform.position;
        shift = Random.Range( -5, 5);
        rb.AddForce(new Vector2(direction.x + shift, direction.y + shift) * _speed);
}

    void Update()
    {
        //spawning
        transform.Rotate(new Vector3(0, 0, rotationSpeed)* Time.deltaTime);
        CheckPosition();
    }
    void OnTriggerEnter2D (Collider2D other) //Powerups
    {   
        int randomPowerup = Random.Range(1,4);
        if(other.CompareTag("Player1"))
        {   
            switch(randomPowerup)
            {
            case 1:
                StartCoroutine(PickupSpeed(other));
            break;

            case 2:
                StartCoroutine(PickupShield(other));
            break;

            case 3:
                StartCoroutine(PickupSlowness(other));
            break;
            }
        }
    }

    IEnumerator PickupSpeed(Collider2D Player1) //speed Powerup
    {
        Debug.Log("Picked up speed!");
        
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        Player1 speed = Player1.GetComponent<Player1>();
        speed._speed *= multiplier;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        speed._speed /= multiplier;
        Destroy(gameObject);
    }

    IEnumerator PickupShield(Collider2D Player1) //Invincibility Powerup
    {
        Debug.Log("Picked up Shield!");
        
        Player1 damage = Player1.GetComponent<Player1>();
        damage.Damage= 0;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        damage.Damage = 1;
        Destroy(gameObject);
    }

    IEnumerator PickupSlowness(Collider2D Player1) //slow powerup
    {
        Debug.Log("Picked up Slowness BITCH!");
        Player1 speed = Player1.GetComponent<Player1>();
        speed._speed /= multiplier;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        speed._speed *= multiplier;
        Destroy(gameObject);
    }

    void CheckPosition() //Spawning
    {
        if(transform.position.x >6.4f || transform.position.x <-6.4f)
        {
            Destroy(gameObject);
        }

        if(transform.position.y >7.3f || transform.position.y <-7.3f)
        {
            Destroy(gameObject);
        }
    }
}
