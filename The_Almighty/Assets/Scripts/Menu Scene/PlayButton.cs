using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private bool _PlayEnter = false;

    void Start()
    {
        
    }
    void Update()
    {
        //PlayButton it needs to check it per frame if player enter is true.
        if (_PlayEnter = true && Input.GetButtonDown("Submit"))
        {
            Debug.Log("It works");
            SceneManager.LoadScene("Gameplay");
        }
    }

    void OnTriggerEnter2D(Collider2D Collision) //PlayButton
    {
        if(Collision.CompareTag("Player1"))
        {
            _PlayEnter = true;
            Debug.Log("yay");
        }
        
    } 
}
