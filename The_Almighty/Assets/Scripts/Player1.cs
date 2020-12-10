using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private GameObject _player2;
    private bool p2alive = false;
    
    void Start()
    {
        transform.position = new Vector3(-2, -3.5f, 0);
    }

    
    void Update()
    {
        Movement();

        //Boundaries of screen
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5),0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, 0);

        if(Input.GetKey(KeyCode.P) && p2alive != true)
        {
            Player2();
        }

    }

    void Movement() //Player movement
    {
        float HorizontalInput = Input.GetAxis("Horizontal1");
        float VerticalInput = Input.GetAxis("Vertical1");

        Vector3 direction = new Vector3 (HorizontalInput, VerticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    void Player2()
    {
        Instantiate(_player2, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
        p2alive = true;
    }
}
