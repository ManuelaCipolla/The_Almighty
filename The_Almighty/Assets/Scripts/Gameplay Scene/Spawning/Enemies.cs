using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private float rotationSpeed;
    private Rigidbody2D rb;
    [SerializeField]
    private Collider2D _collider;
    [SerializeField]
    private float _speed;
    private Vector2 direction;
    private targetPoint target;
    private float shift;

    public float RRminimum = 0f;
    public float RRmaximum = 0f;
    Player1 player1;


    void Start()
    {
        player1 = GetComponent<Player1>();
        _collider = GetComponent<PolygonCollider2D>();
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
        }
    }

}
