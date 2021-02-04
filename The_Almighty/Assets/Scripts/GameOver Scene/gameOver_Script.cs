using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver_Script : MonoBehaviour
{
        public Text scoreGO;
        public Text Coins;
        public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "HIGHSCORE " + Mathf.Round(PlayerPrefs.GetFloat("highScore"));
        scoreGO.text = "SCORE " + Mathf.Round(PlayerPrefs.GetFloat("CurrentScore"));
        Coins.text = "COINS " + PlayerPrefs.GetInt("CurrentCoins");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
