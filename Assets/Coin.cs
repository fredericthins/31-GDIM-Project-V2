using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Purpose: Simple Coin Collection Code
public class Coin : MonoBehaviour
{
    [SerializeField] int coinValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check for player
        if (collision.CompareTag("Player"))
        {
            //Call on the scoreManager singleton to update
            ScoreManager._instance.UpdateScore(coinValue);
            //Destroy itself
            Destroy(gameObject);
        }
    }
}
