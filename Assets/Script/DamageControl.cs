using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    
   
    private void OnTriggerEnter2D(Collider2D collision) 
    {
         if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Debug.Log("Player Colling");
            PlayerController playerController = (PlayerController)collision.gameObject.GetComponent<PlayerController>();
            playerController.killPlayer();
            
        }

    }
    

    
}
