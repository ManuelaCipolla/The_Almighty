using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1_menu : MonoBehaviour
{

    /*private void UIButtons ()
    {
        //PlayButton it needs to check it per frame if player enter is true.
        if (_PlayEnter == true && Input.GetButtonDown("Submit")) //Gameplay button
        {
            Debug.Log("Gameplay true");
            SceneManager.LoadScene("Gameplay");
        }

        if(_SettingEnter == true && Input.GetButtonDown("Submit")) //Setting button
        {
            Debug.Log("Setting true");
            PlayerSettings = true;
            Options.SetActive(true);
            MainMenu.SetActive(false);
            Player1.SetActive(false);
        }

        if(_StoreEnter == true && Input.GetButtonDown("Submit")) //Store button
        {
            Debug.Log("Store true");
            SceneManager.LoadScene("Store");
        }

        if(_ExitEnter == true && Input.GetButtonDown("Submit")) //Exit button
        {
            QuitGame();
            Debug.Log("Exit true");
        }
    }*/

    /*void OnTriggerStay2D(Collider2D Collision) 
    { 
        
        if(Collision.CompareTag("PlayButton"))//Play Button
        {
            _PlayEnter = true;
            Debug.Log("Gameplay works");
            _SettingEnter = false;
            _StoreEnter = false;
            _ExitEnter = false;
        }

        if(Collision.CompareTag("SettingButton")) //Setting button
        {
            _SettingEnter = true;
            Debug.Log("Setting works");
            _PlayEnter = false;
            _StoreEnter = false;
            _ExitEnter = false;
        }

        if(Collision.CompareTag("StoreButton")) //Store button
        {
            _StoreEnter = true;
            Debug.Log("Store works");
            _PlayEnter = false;
            _SettingEnter = false;
            _ExitEnter = false;
        } 

        if(Collision.CompareTag("ExitButton")) //Exit button
        {
            _ExitEnter = true;
            Debug.Log("Exit works");
            _PlayEnter = false;
            _SettingEnter = false;
            _StoreEnter = false;
        }
    } */

}

