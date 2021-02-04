using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu_Buttons : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject Options;
    Button Back;

    //HighScore
    public Text highScore;
    public Text Coins;

    //Tutorial
    public GameObject tutorialHolder;

    void Start()
    {
        //HighScore
        highScore.text = "HIGHSCORE " + Mathf.Round(PlayerPrefs.GetFloat("highScore"));
        Coins.text = "COINS " + PlayerPrefs.GetInt("CurrentCoins");

        //backbutton
        Button btn = Back.GetComponent<Button>();
        btn.onClick.AddListener(SettingsBackButton);

        
    }

    public void TutorialButton()
    {
        tutorialHolder.SetActive(true);
    }

    public void BackTutorialButton()
    {
        tutorialHolder.SetActive(false);
    }


    public void StartButton()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void StoreButton()
    {
        SceneManager.LoadScene("Store");
    }

    public void SettingsButton()
    {
        Options.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void SettingsBackButton() // Back Button
    {
        Debug.Log("it work this bad bad button");
        Options.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void QuitGame() // exit game
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
}
