using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player2 : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    //stats
    public int curHealthP2;
    public int maxHealth = 3;

    public static Player2 player2{get; set;}
    void Start()
    {
        //spawning point
        transform.position = new Vector3(2, -3.5f, 0);
        curHealthP2 = maxHealth;
        player2 = this;
    }


    void Update()
    {
        Movement();

        //boundaries
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5),0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.5f, 3.5f), transform.position.y, 0);
        
        Health();
    }

    void Movement() //Player movement
    {
        float HorizontalInput = Input.GetAxis("Horizontal2");
        float VerticalInput = Input.GetAxis("Vertical2");

        Vector3 direction = new Vector3 (HorizontalInput, VerticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    void Health()
    {
        //Health
        if(curHealthP2 > maxHealth)
        {
            curHealthP2 = maxHealth;
        }

        if(curHealthP2 <= 0)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("hit p2");
            curHealthP2 --;
        }

    }
    void Die() //literal death (in game and real life wowa)
    {
        Debug.Log("YOU DEAD FUCKER number 2");
        Destroy(gameObject, 1);
        SceneManager.LoadScene("Gameplay");
    }
    
}
