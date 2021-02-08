using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreController : MonoBehaviour
{
    [Header("Coins")]
    public Text Coins;
    public int MoneyToBuy;
    public int MoneyToBuyBG;
    public int Currency;

    //Playerprefs for gameplay
    [Header("Objects Values")]
    public int playerValue;
    public int BackgroundValue;
    public int MageBought = 0; //false
    public int BearBought = 0; //false

    //Backgrounds
    public int item2Bought = 0; //false
    public int item3Bought = 0; //false
    public int item4Bought = 0; //false
    public int item5Bought = 0; //false
    public int item6Bought = 0; //false
    public int item7Bought = 0; //false
    public int item8Bought = 0; //false
    public int item9Bought = 0; //false
    public int item10Bought = 0; //false
    public int item11Bought = 0; //false
    public int item12Bought = 0; //false
    public int item13Bought = 0; //false
    public int item14Bought = 0; //false
    public int item15Bought = 0; //false
    public int item16Bought = 0; //false
    public int item17Bought = 0; //false
    public int item18Bought = 0; //false

[Header("Magician")]
    //Magician
    [SerializeField]
    GameObject BuyMage;

    [SerializeField]
    GameObject EquipMage;

[Header("Bear")]
    //Bear
    [SerializeField]
    GameObject BuyBear;

    [SerializeField]
    GameObject EquipBear;

[Header("Clown")]
    [SerializeField]
    GameObject EquipClown;

    //Background buy
    [Header("Backgrounds BUY")]
    public GameObject item2Buy;
    public GameObject item3Buy;
    public GameObject item4Buy;
    public GameObject item5Buy;
    public GameObject item6Buy;
    public GameObject item7Buy;
    public GameObject item8Buy;
    public GameObject item9Buy;
    public GameObject item10Buy;
    public GameObject item11Buy;
    public GameObject item12Buy;
    public GameObject item13Buy;
    public GameObject item14Buy;
    public GameObject item15Buy;
    public GameObject item16Buy;
    public GameObject item17Buy;
    public GameObject item18Buy;

    //Background equip
    [Header("Background EQUIP")]
    public GameObject item1Equip;
    public GameObject item2Equip;
    public GameObject item3Equip;
    public GameObject item4Equip;
    public GameObject item5Equip;
    public GameObject item6Equip;
    public GameObject item7Equip;
    public GameObject item8Equip;
    public GameObject item9Equip;
    public GameObject item10Equip;
    public GameObject item11Equip;
    public GameObject item12Equip;
    public GameObject item13Equip;
    public GameObject item14Equip;
    public GameObject item15Equip;
    public GameObject item16Equip;
    public GameObject item17Equip;
    public GameObject item18Equip;

    // CAMERA SHAKE //
    

[Header("ChangeColor")]
    public GameObject ChangeColor;
    public Animator camShake;

    [Header("Audio")]
    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        //for audio to play
        audioSource = GetComponent<AudioSource>();

        //PlayerPrefs.SetInt("HighCoins", 10000);
        MoneyToBuy -= 500;
        MoneyToBuyBG -= 300;
        
                    // CHEATS  //
        /*PlayerPrefs.SetInt("MageBought", 0);
        PlayerPrefs.SetInt("BearBought", 0);
        PlayerPrefs.SetInt("PlayerActive", 3);
        PlayerPrefs.SetInt("BackgroundValue", 0);  
        
        PlayerPrefs.SetInt("item2Bought", 0);
        PlayerPrefs.SetInt("item3Bought", 0);
        PlayerPrefs.SetInt("item4Bought", 0);
        PlayerPrefs.SetInt("item5Bought", 0);
        PlayerPrefs.SetInt("item6Bought", 0);
        PlayerPrefs.SetInt("item7Bought", 0);
        PlayerPrefs.SetInt("item8Bought", 0);
        PlayerPrefs.SetInt("item9Bought", 0);
        PlayerPrefs.SetInt("item10Bought", 0);
        PlayerPrefs.SetInt("item11Bought", 0);
        PlayerPrefs.SetInt("item12Bought", 0);
        PlayerPrefs.SetInt("item13Bought", 0);
        PlayerPrefs.SetInt("item14Bought", 0);
        PlayerPrefs.SetInt("item15Bought", 0);
        PlayerPrefs.SetInt("item16Bought", 0);
        PlayerPrefs.SetInt("item17Bought", 0);
        PlayerPrefs.SetInt("item18Bought", 0);*/
        
        playerValue = PlayerPrefs.GetInt("playerActive");
        BackgroundValue = PlayerPrefs.GetInt("BackgroundValue");
        
        if(BackgroundValue == 0)
        {
            BackgroundValue = 1;
            PlayerPrefs.SetInt("BackgroundValue", 1);
        }
        //
        MageBought = PlayerPrefs.GetInt("MageBought");
        BearBought = PlayerPrefs.GetInt("BearBought");

    }
    void Update()
    {    
        Currency = PlayerPrefs.GetInt("HighCoins");
        Coins.text = "COINS " + PlayerPrefs.GetInt("HighCoins");
        CheckBuyForPlayers();
        CheckEquipForPlayers();
        CheckBuyForBackgrounds();
        CheckEquipForBackground();
    }
    
    // BACK BUTTON //
        public void TaskOnClick() //backbutton
    {
        SceneManager.LoadScene("Main Menu");
        PlayerPrefs.Save();
    }

    //CHECK BUY BUTTON PLAYER//
    void CheckBuyForPlayers()
    {
        if(PlayerPrefs.GetInt("MageBought") == 1) //true
        {
            BuyMage.SetActive(false);
        }

        if(PlayerPrefs.GetInt("BearBought") == 1) //true
        {
            BuyBear.SetActive(false);
        }
    }

    //CHECK EQUIP BUTTON  PLAYER//
    void CheckEquipForPlayers()
    {
        if(playerValue == 1) //mage
        {
            Debug.Log("MageEqu 1");
            EquipMage.SetActive(false);
            EquipBear.SetActive(true);
            EquipClown.SetActive(true);
        }

        if(playerValue == 2) //bear
        {
            Debug.Log("BearEqu 1");
            EquipMage.SetActive(true);
            EquipClown.SetActive(true);
            EquipBear.SetActive(false);
        }

        if(playerValue == 3) //clown
        {
            Debug.Log("ClownEqu 1");
            EquipMage.SetActive(true);
            EquipBear.SetActive(true);
            EquipClown.SetActive(false);
        }
    }

    // CHECK BUY BUTTON BACKGROUND //

        void CheckBuyForBackgrounds()
    {
        if(PlayerPrefs.GetInt("item2Bought") == 1) //true
        {
            item2Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item3Bought") == 1) //true
        {
            item3Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item4Bought") == 1) //true
        {
            item4Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item5Bought") == 1) //true
        {
            item5Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item6Bought") == 1) //true
        {
            item6Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item7Bought") == 1) //true
        {
            item7Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item8Bought") == 1) //true
        {
            item8Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item9Bought") == 1) //true
        {
            item9Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item10Bought") == 1) //true
        {
            item10Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item11Bought") == 1) //true
        {
            item11Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item12Bought") == 1) //true
        {
            item12Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item13Bought") == 1) //true
        {
            item13Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item14Bought") == 1) //true
        {
            item14Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item15Bought") == 1) //true
        {
            item15Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item16Bought") == 1) //true
        {
            item16Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item17Bought") == 1) //true
        {
            item17Buy.SetActive(false);
        }

        if(PlayerPrefs.GetInt("item18Bought") == 1) //true
        {
            item18Buy.SetActive(false);
        }
    }

    // CHECK EQUIP BUTTON BACKGROUND //
    void CheckEquipForBackground()
    {
        if(BackgroundValue == 1)
        {
            item1Equip.SetActive(false);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 2)
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(false);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 3) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(false);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 4) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(false);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 5) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(false);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 6) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(false);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 7) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(false);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 8) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(false);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 9) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(false);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 10) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(false);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 11) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(false);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 12) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(false);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 13) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(false);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 14) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(false);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 15) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(false);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 16) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(false);
            item17Equip.SetActive(true);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 17) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(false);
            item18Equip.SetActive(true);
        }

        if(BackgroundValue == 18) 
        {
            item1Equip.SetActive(true);
            item2Equip.SetActive(true);
            item3Equip.SetActive(true);
            item4Equip.SetActive(true);
            item5Equip.SetActive(true);
            item6Equip.SetActive(true);
            item7Equip.SetActive(true);
            item8Equip.SetActive(true);
            item9Equip.SetActive(true);
            item10Equip.SetActive(true);
            item11Equip.SetActive(true);
            item12Equip.SetActive(true);
            item13Equip.SetActive(true);
            item14Equip.SetActive(true);
            item15Equip.SetActive(true);
            item16Equip.SetActive(true);
            item17Equip.SetActive(true);
            item18Equip.SetActive(false);
        }
    }

    // BUY PLAYERS //
    public void BuyMagicianOnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 500)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuy);
            Debug.Log("Mage Bought");
            BuyMage.SetActive(false);
            //
            MageBought = 1; //true
            PlayerPrefs.SetInt("MageBought", MageBought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    
    }

    public void BuyBearOnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 500)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuy);
            Debug.Log("Bear bought");
            BuyBear.SetActive(false);
            //
            BearBought = 1; //true
            PlayerPrefs.SetInt("BearBought", BearBought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    // EQUIP PLAYERS //
    public void EquipMagicianOnClick()
    {
        Debug.Log("EquippedMage");
        playerValue = 1;
        PlayerPrefs.SetInt("playerActive", playerValue);
    }

    public void EquipBearOnClick()
    {
        Debug.Log("EquippedBear");
        playerValue = 2;
        PlayerPrefs.SetInt("playerActive", playerValue);
    }

    public void EquipClownOnClick()
    {
        Debug.Log("EquippedClown");
        playerValue = 3;
        PlayerPrefs.SetInt("playerActive", playerValue);
    }

    // BUY ITEMS ON CLICK //
    public void BuyItem2_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG2 bought");
            item2Buy.SetActive(false);
            //
            item2Bought = 1; //true
            PlayerPrefs.SetInt("item2Bought", item2Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem3_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG3 bought");
            item3Buy.SetActive(false);
            //
            item3Bought = 1; //true
            PlayerPrefs.SetInt("item3Bought", item3Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem4_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG4 bought");
            item4Buy.SetActive(false);
            //
            item4Bought = 1; //true
            PlayerPrefs.SetInt("item4Bought", item4Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem5_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG5 bought");
            item5Buy.SetActive(false);
            //
            item5Bought = 1; //true
            PlayerPrefs.SetInt("item5Bought", item5Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem6_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG6 bought");
            item6Buy.SetActive(false);
            //
            item6Bought = 1; //true
            PlayerPrefs.SetInt("item6Bought", item6Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem7_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG7 bought");
            item7Buy.SetActive(false);
            //
            item7Bought = 1; //true
            PlayerPrefs.SetInt("item7Bought", item7Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem8_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG8 bought");
            item8Buy.SetActive(false);
            //
            item8Bought = 1; //true
            PlayerPrefs.SetInt("item8Bought", item8Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem9_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG9 bought");
            item9Buy.SetActive(false);
            //
            item9Bought = 1; //true
            PlayerPrefs.SetInt("item9Bought", item9Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem10_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG10 bought");
            item10Buy.SetActive(false);
            //
            item10Bought = 1; //true
            PlayerPrefs.SetInt("item10Bought", item10Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem11_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG11 bought");
            item11Buy.SetActive(false);
            //
            item11Bought = 1; //true
            PlayerPrefs.SetInt("item11Bought", item11Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem12_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG12 bought");
            item12Buy.SetActive(false);
            //
            item12Bought = 1; //true
            PlayerPrefs.SetInt("item12Bought", item12Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem13_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG13 bought");
            item13Buy.SetActive(false);
            //
            item13Bought = 1; //true
            PlayerPrefs.SetInt("item13Bought", item13Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem14_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG14 bought");
            item14Buy.SetActive(false);
            //
            item14Bought = 1; //true
            PlayerPrefs.SetInt("item14Bought", item14Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem15_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG15 bought");
            item15Buy.SetActive(false);
            //
            item15Bought = 1; //true
            PlayerPrefs.SetInt("item15Bought", item15Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem16_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG16 bought");
            item16Buy.SetActive(false);
            //
            item16Bought = 1; //true
            PlayerPrefs.SetInt("item16Bought", item16Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem17_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG17 bought");
            item17Buy.SetActive(false);
            //
            item17Bought = 1; //true
            PlayerPrefs.SetInt("item17Bought", item17Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

    public void BuyItem18_OnClick()
    {
        if(PlayerPrefs.GetInt("HighCoins") >= 300)
        {
            PlayerPrefs.SetInt("HighCoins", Currency + MoneyToBuyBG);
            Debug.Log("BG18 bought");
            item18Buy.SetActive(false);
            //
            item18Bought = 1; //true
            PlayerPrefs.SetInt("item18Bought", item18Bought);
            //audio
            audioSource.Play();
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
            StartCoroutine(ShakeCamera());
        }
    }

// EQUIP ITEMS ON CLICK //
    public void EquipItem1OnClick()
    {
        Debug.Log("EquippedItem1");
        BackgroundValue = 1;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem2OnClick()
    {
        Debug.Log("EquippedItem2");
        BackgroundValue = 2;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

        public void EquipItem3OnClick()
    {
        Debug.Log("EquippedItem3");
        BackgroundValue = 3;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }
    public void EquipItem4OnClick()
    {
        Debug.Log("EquippedItem4");
        BackgroundValue = 4;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem5OnClick()
    {
        Debug.Log("EquippedItem5");
        BackgroundValue = 5;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem6OnClick()
    {
        Debug.Log("EquippedItem6");
        BackgroundValue = 6;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem7OnClick()
    {
        Debug.Log("EquippedItem7");
        BackgroundValue = 7;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem8OnClick()
    {
        Debug.Log("EquippedItem8");
        BackgroundValue = 8;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem9OnClick()
    {
        Debug.Log("EquippedItem9");
        BackgroundValue = 9;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem10OnClick()
    {
        Debug.Log("EquippedItem10");
        BackgroundValue = 10;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem11OnClick()
    {
        Debug.Log("EquippedItem11");
        BackgroundValue = 11;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem12OnClick()
    {
        Debug.Log("EquippedItem12");
        BackgroundValue = 12;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem13OnClick()
    {
        Debug.Log("EquippedItem13");
        BackgroundValue = 13;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem14OnClick()
    {
        Debug.Log("EquippedItem14");
        BackgroundValue = 14;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem15OnClick()
    {
        Debug.Log("EquippedItem15");
        BackgroundValue = 15;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem16OnClick()
    {
        Debug.Log("EquippedItem16");
        BackgroundValue = 16;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem17OnClick()
    {
        Debug.Log("EquippedItem17");
        BackgroundValue = 17;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    public void EquipItem18OnClick()
    {
        Debug.Log("EquippedItem18");
        BackgroundValue = 18;
        PlayerPrefs.SetInt("BackgroundValue", BackgroundValue);
    }

    IEnumerator ShakeCamera()
    {
        ChangeColor.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        ChangeColor.SetActive(false);
    }
}