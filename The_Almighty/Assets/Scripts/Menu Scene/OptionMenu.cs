using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Options;
    public GameObject Player1;
public Player1_menu PlayerScript;

    Button Back;

    void Start()
    {
        Button btn = Back.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    public void TaskOnClick()
    {
        Debug.Log("it work this bad bad button");
        Options.SetActive(false);
        MainMenu.SetActive(true);
        Player1.SetActive(true);
        PlayerScript = gameObject.GetComponent<Player1_menu>();
        PlayerScript.PlayerSettings = false;
        
    }

}
