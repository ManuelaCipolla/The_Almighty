using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreController : MonoBehaviour
{
    public Text Coins;
    Button Back;

    void Update()
{
    Coins.text = "COINS " + PlayerPrefs.GetInt("CurrentCoins");
}
    public void TaskOnClick()
    {
    SceneManager.LoadScene("Main Menu");
    }
}