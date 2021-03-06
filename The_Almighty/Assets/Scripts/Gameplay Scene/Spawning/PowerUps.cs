﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //Powerups
    public float multiplier = 2f;
    public float duration = 10f;

    //public GameObject Shield;
    public GameObject instance;

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
        int randomPowerup = Random.Range(1,5);
        if(other.CompareTag("Player1"))
        {   
            switch(randomPowerup)
            {
            case 1:
                StartCoroutine(PickupSpeed(other));
            break;

            case 2:
                pickUpHealth(other);
            break;

            case 3:
                StartCoroutine(PickUpSlowTime(other));
            break;

            case 4:
                StartCoroutine(PickupSlowness(other));
            break;

            case 5:
                //StartCoroutine(PickUpChangeSize(other));
            break;

            case 6:
                //StartCoroutine(GetComponent<Player1>().PlayerShield());
            break;
            }
        }
    }

    void pickUpHealth(Collider2D Player1)
    {
        Player1 Health = Player1.GetComponent<Player1>();
        Health.curHealth = Health.curHealth +1;
        Destroy(gameObject);
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

    IEnumerator PickupSlowness(Collider2D Player1) //slow powerup
    {
        Debug.Log("Picked up Slowness BITCH!");
        Player1 speed = Player1.GetComponent<Player1>();
        speed._speed /= 3f;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        speed._speed *= 3f;
        Destroy(gameObject);
    }

    IEnumerator PickUpSlowTime(Collider2D Player1)
    {
        Debug.Log("Picked up slowTime");
        Time.timeScale= 0.5f;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        Time.timeScale= 1;
        Destroy(gameObject);
    }

    /*IEnumerator PickUpChangeSize(Collider2D Player1)
    {
        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        Debug.Log("Picked up Change size");
        Player1Holder.transform.localScale += scaleChange;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        Player1Holder.transform.localScale -= scaleChange;
        Destroy(gameObject);
    }*/

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
