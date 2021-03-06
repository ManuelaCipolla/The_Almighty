using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //p2 persistent data
    /*public GameObject Player2;
    public bool player2Active;
    public GameObject P2text;*/

    //Score
    public float GameScore = 0f;
    public Text scoreText;
    public float HighScore;
    public int pointPerSeconds;



    public static GameManager gameManagerS{get; set;}
    void Start()
    {
        gameManagerS = this;
        //player2Active = PersistentData.data.player2Active;
        //Player2.SetActive(false);
        GameScore = 0;
    }

    void Update()
    {
        //p2
        /*if(!player2Active)
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
        }*/
        if(PlayerPrefs.GetInt("playerActive") == 2)
        {
            
        }

        //Score
        GameScore += pointPerSeconds * Time.deltaTime;
        scoreText.text = "SCORE " + Mathf.Round(GameScore);
        PlayerPrefs.SetFloat("CurrentScore", GameScore);
        HighScore = GameScore;

        if(GameScore > PlayerPrefs.GetFloat("highScore"))
        {
            PlayerPrefs.SetFloat("highScore", HighScore);
        }
        
    }

    //persistent data
    /*public void SavePlayer()
    {
        PersistentData.data.player2Active = player2Active;
    }*/



    public void LoadMenu()
    {
        Time.timeScale =1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }
}
