using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreController : MonoBehaviour
{
    public Text Coins;
    Button Back;
    Button Buy;

    //Magician
    [SerializeField]
    GameObject BuyMage;
    [SerializeField]
    GameObject EquipMage;

    //Bear
    [SerializeField]
    GameObject BuyBear;
    [SerializeField]
    GameObject EquipBear;

    [SerializeField]
    GameObject EquipClown;

    //Playerprefs for gameplay
    public int playerValue;

    //Buy Bool
    public int MageBought = 0; //false
    public int BearBought = 0; //false


    public int ClownEquipped = 0; //true
    public int MageEquipped = 0; //false
    public int BearEquipped = 0; //false

    //to set new playerprefs
    public int MoneyToBuy;
    public int Currency;


    void Start()
    {
        MoneyToBuy -= 700;
        //PlayerPrefs.SetInt("CurrentCoins", 3000);
        Currency = PlayerPrefs.GetInt("CurrentCoins");
        PlayerPrefs.GetInt("playerActive");
        PlayerPrefs.GetInt("MageEquipped");
        PlayerPrefs.GetInt("BearEquipped");
        PlayerPrefs.GetInt("ClownEquipped");
        
        //PlayerPrefs.SetInt("MageBought", 0);
        //PlayerPrefs.SetInt("BearBought", 0);
        //cheating potato

        
    }
    void Update()
    {    

    Coins.text = "COINS " + PlayerPrefs.GetInt("CurrentCoins");

        CheckThingsForPlayers();

    }

    void CheckThingsForPlayers()
    {
        if(PlayerPrefs.GetInt("MageBought") == 1) //true
        {
            BuyMage.SetActive(false);
        }

        if(PlayerPrefs.GetInt("BearBought") == 1) //true
        {
            BuyBear.SetActive(false);
        }

        ////

        if(PlayerPrefs.GetInt("MageEquipped") == 1) //true
        {
            EquipMage.SetActive(false);
            EquipBear.SetActive(true);
            EquipClown.SetActive(true);
            MageEquipped = 0;
            PlayerPrefs.SetInt("MageEquipped", 0); //false
        }

        if(PlayerPrefs.GetInt("BearEquipped") == 1)//true
        {
            EquipBear.SetActive(false);
            EquipMage.SetActive(true);
            EquipClown.SetActive(true);
            BearEquipped = 0;
            PlayerPrefs.SetInt("BearEquipped", 0); //false
        }

        if(PlayerPrefs.GetInt("ClownEquipped") == 1) //true
        {
            EquipClown.SetActive(false);
            EquipBear.SetActive(true);
            EquipMage.SetActive(true);
            ClownEquipped = 0;
            PlayerPrefs.SetInt("ClownEquipped", 0); //false
            
        }

    }


    public void TaskOnClick()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void BuyMagicianOnClick()
    {
        if(PlayerPrefs.GetInt("CurrentCoins") >= 700)
        {
            PlayerPrefs.SetInt("CurrentCoins", Currency + MoneyToBuy);
            Debug.Log("Mage Bought");
            BuyMage.SetActive(false);
            //
            MageBought = 1; //true
            PlayerPrefs.SetInt("MageBought", MageBought);
        }
        else
        {
            Debug.Log("Play more, you dont have enough");
        }
        
    }

    public void EquipMagicianOnClick()
    {
        Debug.Log("EquippedMage");
        playerValue = 1;
        PlayerPrefs.SetInt("playerActive", playerValue);

        MageEquipped = 1; //true
        PlayerPrefs.SetInt("MageEquipped", MageEquipped);
    }
    public void BuyBearOnClick()
    {
        if(PlayerPrefs.GetInt("CurrentCoins") >= 700)
        {
            PlayerPrefs.SetInt("CurrentCoins", Currency + MoneyToBuy);
            Debug.Log("Bear bought");
            BuyBear.SetActive(false);
            //
            BearBought = 1; //true
            PlayerPrefs.SetInt("BearBought", BearBought);
        }
        
        else
        {
            Debug.Log("Play more, you dont have enough");
        }

    }
    public void EquipBearOnClick()
    {
        Debug.Log("EquippedBear");
        playerValue = 2;
        PlayerPrefs.SetInt("playerActive", playerValue);
        BearEquipped = 1; //true
        PlayerPrefs.SetInt("BearEquipped", BearEquipped);
    }

    public void EquipClownOnClick()
    {
        Debug.Log("EquippedClown");
        playerValue = 3;
        PlayerPrefs.SetInt("playerActive", playerValue);
        ClownEquipped = 1; //true
        PlayerPrefs.SetInt("ClownEquipped", ClownEquipped);
    }
}