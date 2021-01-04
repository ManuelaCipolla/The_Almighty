using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnP2 : MonoBehaviour
{


    //second players references
    [SerializeField]
    private GameObject _player2;
    public bool p2alive = false;

    public GameObject P2text;

    void Update()
    {
        
        //spawning of player2
        if(Input.GetKey(KeyCode.P) && p2alive != true)
        {
            Player2();
            P2text.SetActive(false);
        }
        
        if(p2alive == true)
        {
            DontDestroyOnLoad(_player2);
        }
        
    }

    void Player2() //spawning player2
    {
        _player2.SetActive(true);
        //Instantiate(_player2, transform.position + new Vector3(4, 0, 0), Quaternion.identity);
        p2alive = true;
        
    }
}
