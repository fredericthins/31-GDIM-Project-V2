using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickUp : MonoBehaviour
{
    [SerializeField] float powerUpTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check for player
        if (collision.CompareTag("Player"))
        {
            //Plays the sound effect for collecting the power up 
            SoundManagerScript.PlaySound("powerUp");
            //Gather player health/combat stats
            PlayerCombat player = collision.gameObject.GetComponent<PlayerCombat>();
            //Player's attack speed is boosted for poweruptime seconds
            player.Boosted(powerUpTime);
            
            //Destroy itself
            Destroy(gameObject);
        }
    }
}
