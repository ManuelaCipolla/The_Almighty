using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Options;

    Button Back;

    void Start()
    {
        Button btn = Back.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    public void TaskOnClick()
    {
        Debug.Log("it work this bad bad button");
    }
    /*public void btnSetActive()
    {
        
        MainMenu.SetActive(true);
        Options.SetActive(false);
    }*/
}
