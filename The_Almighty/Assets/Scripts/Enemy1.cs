using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y <= 4.46f)
        {
            if(transform.position.y >= -4.46f)
            {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
            }
        }

        else if (transform.position.y > -4.47f)
        {
            if(transform.position.y <= 4.47f)
            {
                transform.Translate(Vector3.up * _speed * Time.deltaTime);
            }
        }

        else if (transform.position.x <= 3.22f)
        {
            if (transform.position.x >= -3.22f)
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }
        }

        else if (transform.position.x >= -3.23f)
        {
            if (transform.position.x <= 3.23f)
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }
        }
    }

}
