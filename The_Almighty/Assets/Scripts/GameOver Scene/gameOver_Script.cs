using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver_Script : MonoBehaviour
{
        public Text scoreGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreGO.text = "SCORE " + Mathf.Round(PlayerPrefs.GetFloat("CurrentScore"));
    }
}
