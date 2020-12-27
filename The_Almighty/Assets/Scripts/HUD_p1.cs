using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_p1 : MonoBehaviour
{

    public Sprite[] HeartSprites;
    public Image HeartUI;
    private Player1 Player1;

    void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1>();
    }


    void Update()
    {
        HeartUI.sprite = HeartSprites[Player1.curHealth];
    }
}
