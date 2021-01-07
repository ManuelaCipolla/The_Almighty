using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player2;
    public bool player2Active;
    public GameObject P2text;

    void Start()
    {
        player2Active = PersistentData.data.player2Active;
        Player2.SetActive(false);
    }

    void Update()
    {
        if(!player2Active)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                player2Active = true;
                SavePlayer();
                Player2.SetActive(true);
                P2text.SetActive(false);
            }
        }

        else if(player2Active)
        {
            Player2.SetActive(true);
        }
    }

    public void SavePlayer()
    {
        PersistentData.data.player2Active = player2Active;
    }
}
