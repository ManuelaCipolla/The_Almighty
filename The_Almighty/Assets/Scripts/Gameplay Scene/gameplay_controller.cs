using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameplay_controller : MonoBehaviour
{
public SpriteRenderer spriteRenderer;
public Sprite[] MageSprite;
public Animator Animator;
public GameObject MagicianPlayer;


    void Start()
    {
        Animator = GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        int playerActive = PlayerPrefs.GetInt("playerActive");

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
    }
    void Update()
    {

    }

    /*void ChangeSpriteMage()
    {
        spriteRenderer.sprite = MageSprite[5];
        //MageAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/SPRITE SHEET 2_Magitian_0");
    }*/
}
