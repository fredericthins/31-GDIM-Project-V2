using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int maxHealth;
    [SerializeField] HealthBar hpBar;
    public int attack;

    void Awake()
    {
        health = maxHealth;
        hpBar.SetHealth(health,maxHealth);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Damage")){
            TakeDamage(1);
        }
    }   
    void TakeDamage(int damage){
        health -= damage;
        if(health <= 0){
            Destroy(gameObject);
        }else{
            hpBar.SetHealth(health, maxHealth);
        }
    }
}