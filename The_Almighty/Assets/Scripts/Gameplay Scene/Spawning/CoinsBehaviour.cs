﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsBehaviour : MonoBehaviour
{
    private float rotationSpeed;
    private Rigidbody2D rb;

    [SerializeField]
    private float _speed;
    private Vector2 direction;
    private targetPoint target;
    private float shift;

    public float RRminimum = 0f;
    public float RRmaximum = 0f;

    //for sound/death
    public SpriteRenderer spriteRenderer;
    public Collider2D TriggerCollider;

    void Start()
    {
        rotationSpeed = Random.Range(-25,25);
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<targetPoint>();
        direction = target.transform.position - transform.position;
        shift = Random.Range( RRminimum, RRmaximum);
        rb.AddForce(new Vector2(direction.x + shift, direction.y + shift) * _speed);
        
    }


    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed)* Time.deltaTime);
        CheckPosition();
    }

        public void CheckPosition()
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            Destroy(gameObject);
            //StartCoroutine(onDestroyRoutine());
        }
    }
    //old way the sound was done
    /*IEnumerator onDestroyRoutine()
    {
        audioSource.Play();
        spriteRenderer.color = new Color(0f, 0f, 0f, 0f);
        TriggerCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }*/
}
