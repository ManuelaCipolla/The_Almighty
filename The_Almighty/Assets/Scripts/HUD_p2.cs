using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_p2 : MonoBehaviour
{

    public Sprite[] HeartSprites2;
    public Image HeartUI2;
    private Player2 Player2;

    private bool OnactiveUI2 = false;


    void Start()
    {
        GetComponent<Player1>();
        Player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2>();
        
    }


    void Update()
    {
        OnactiveUI2 = HeartUI2;
        if (GetComponent<Player1>().p2alive != false)
        {   
            OnactiveUI2 = true;
           // HeartUI2 = Visible;
            HeartUI2.sprite = HeartSprites2[Player2.curHealthP2];
        }
    }
}
