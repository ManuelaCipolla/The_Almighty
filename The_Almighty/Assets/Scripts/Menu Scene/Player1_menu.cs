using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_menu : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    void Start()
    {
        transform.position = new Vector3(-2, -3.5f, 0);
    }

    void Update()
    {
        //Boundaries of screen
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5),0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, 0);
        Movement();
    }

        private void Movement() //Player movement
    {
        float HorizontalInput = Input.GetAxis("Horizontal1");
        float VerticalInput = Input.GetAxis("Vertical1");

        Vector3 direction = new Vector3 (HorizontalInput, VerticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
    }

}

