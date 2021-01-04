using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Options;

    public void btnSetActive()
    {
        MainMenu.SetActive(true);
        Options.SetActive(false);
    }
}
