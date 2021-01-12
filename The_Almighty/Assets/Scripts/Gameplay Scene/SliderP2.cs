using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderP2 : MonoBehaviour


{

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameManagerS.player2Active == true)
        {
            gameObject.SetActive(true);
            transform.position = new Vector3(Player2.player2.transform.position.x, Player2.player2.transform.position.y + -0.53f, Player2.player2.transform.position.z);
        }
        
    }
}
