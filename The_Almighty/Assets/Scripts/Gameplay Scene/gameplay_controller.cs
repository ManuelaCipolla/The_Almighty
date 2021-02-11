using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameplay_controller : MonoBehaviour
{
public SpriteRenderer spriteRenderer;
public Animator Animator;

// BACKGROUND HOLDER //
[Header("Backgrounds")]
public GameObject item1;
public GameObject item2;
public GameObject item3;
public GameObject item4;
public GameObject item5;
public GameObject item6;
public GameObject item7;
public GameObject item8;
public GameObject item9;
public GameObject item10;
public GameObject item11;
public GameObject item12;
public GameObject item13;
public GameObject item14;
public GameObject item15;
public GameObject item16;
public GameObject item17;
public GameObject item18;

[Header("TutorialPopUp")]
public GameObject TutorialHolder;
public int TutorialActive; //false
public Toggle tutorialOff;
public bool isOn;

    //Pause in Gameplay scene
    public static bool GameIsPaused = false;
    public GameObject pauseUI;

    void Start()
    
    {
        Animator = GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        int playerActive = PlayerPrefs.GetInt("playerActive");
        int BackgroundActive = PlayerPrefs.GetInt("BackgroundValue");
        TutorialActive = PlayerPrefs.GetInt("TutorialActive");

        //PlayerPrefs.SetInt("TutorialActive", 0);

        tutorialOff = GetComponent<Toggle>();

        Time.timeScale = 0f;

        if(TutorialActive == 2)
        {
            Debug.Log("Tutorial 2");
            Time.timeScale = 1f;
            TutorialHolder.SetActive(false);
        }

        //Magician
        if(playerActive == 1)
        {
            Debug.Log("Mage 1");
            Animator.SetBool("MageActive", true);
            Animator.SetBool("ClownActive", false);
            Animator.SetBool("BearActive", false);
            //ChangeSpriteMage();
        }

        //Bear
        if(playerActive == 2)
        {
            Debug.Log("Bear 2");
            Animator.SetBool("BearActive", true);
            Animator.SetBool("ClownActive", false);
            Animator.SetBool("MageActive", false);
        }

        //Clown
        if(playerActive == 3)
        {
            Debug.Log("Clown 3");
            Animator.SetBool("ClownActive", true);
            Animator.SetBool("BearActive", false);
            Animator.SetBool("MageActive", false);
        }

        if(BackgroundActive == 1)
        {
            item1.SetActive(true);
        }

        if(BackgroundActive == 2)
        {
            item2.SetActive(true);
        }

        if(BackgroundActive == 3)
        {
            item3.SetActive(true);
        }

        if(BackgroundActive == 4)
        {
            item4.SetActive(true);
        }

        if(BackgroundActive == 5)
        {
            item5.SetActive(true);
        }

        if(BackgroundActive == 6)
        {
            item6.SetActive(true);
        }

        if(BackgroundActive == 7)
        {
            item7.SetActive(true);
        }

        if(BackgroundActive == 8)
        {
            item8.SetActive(true);
        }

        if(BackgroundActive == 9)
        {
            item9.SetActive(true);
        }

        if(BackgroundActive == 10)
        {
            item10.SetActive(true);
        }

        if(BackgroundActive == 11)
        {
            item11.SetActive(true);
        }

        if(BackgroundActive == 12)
        {
            item12.SetActive(true);
        }

        if(BackgroundActive == 13)
        {
            item13.SetActive(true);
        }

        if(BackgroundActive == 14)
        {
            item14.SetActive(true);
        }

        if(BackgroundActive == 15)
        {
            item15.SetActive(true);
        }

        if(BackgroundActive == 16)
        {
            item16.SetActive(true);
        }

        if(BackgroundActive == 17)
        {
            item17.SetActive(true);
        }

        if(BackgroundActive == 18)
        {
            item18.SetActive(true);
        }

    }

    void Update()
    {
        TutorialActive = PlayerPrefs.GetInt("TutorialActive");
        //Pause
        PauseMenu();

        if(TutorialActive == 1)
        {
            Time.timeScale = 1f;
            TutorialActive = 2;
            PlayerPrefs.SetInt("TutorialActive", TutorialActive);
        }
    }

    public void BackTutorialOnClick()
    {
        TutorialHolder.SetActive(false);
        Time.timeScale = 1f;
        if(isOn == true)
        {
        TutorialActive = 1;
        PlayerPrefs.SetInt("TutorialActive", TutorialActive);
        }
    }

    public void TutorialOffToggle(bool tog)
    {
        isOn = true;
    }

        //PauseMenu
    void PauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        else
        {
            
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
