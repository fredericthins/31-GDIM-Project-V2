using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPickup : MonoBehaviour
{
    //Time that the player is boosted for
    [SerializeField] int speedValue = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check for player
        if (collision.CompareTag("Player"))
        {
            //Gather player movement variables
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.RunBoosted(speedValue);

            Destroy(gameObject);
        }
    }
}
