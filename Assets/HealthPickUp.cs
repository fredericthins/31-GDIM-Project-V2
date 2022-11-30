using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] int healthValue = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check for player
        if (collision.CompareTag("Player"))
        {
            //Gather player health/combat stats
            PlayerCombat player = collision.gameObject.GetComponent<PlayerCombat>();
            if(player.health < player.maxHealth){
                //Player heals/takes negative damage - functionally the same
                player.TakeDamage(-healthValue);
                
                //Destroy itself
                Destroy(gameObject);
            }

        }
    }
}
