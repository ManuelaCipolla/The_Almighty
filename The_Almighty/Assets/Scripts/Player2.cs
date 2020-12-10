using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    void Start()
    {
        transform.position = new Vector3(2, -3.5f, 0);
    }


    void Update()
    {
        Movement();

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5),0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, 0);
    }

    void Movement() //Player movement
    {
        float HorizontalInput = Input.GetAxis("Horizontal2");
        float VerticalInput = Input.GetAxis("Vertical2");

        Vector3 direction = new Vector3 (HorizontalInput, VerticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
