using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Purpose: Control animations and mechanisms of attacking and being attacked
public class PlayerCombat : MonoBehaviour
{
    PlayerMovement playerMovement;
    
    Animator playerAnim;

    //For our attack, the script will use a collider element in order to represent the "weapon"
    [SerializeField] GameObject hitCollider;

    //Attack Variables
    //Base Attack Speed
    [SerializeField] float baseAS;
    //Current/Real time attack speed
    float atkSpd;
    [SerializeField] float atkSpdBoost;
    bool isAttacking = false;
    bool isDamagedBoosted = false;
    [SerializeField] GameObject damageBoostIcon;
    
    //Health Variables
    //Current Health
    public int health;
    public int maxHealth;
    [SerializeField] HealthBar hpBar;

    void Awake()
    {
        atkSpd = baseAS;
        playerMovement = GetComponent<PlayerMovement>();
        health = maxHealth;
        hpBar.SetHealth(health,maxHealth);
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Sword Swing
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(Attack(0.1f));
        }
    }

    //Attack will enable the "weapon" hurtbox for the atkSpeed value.
    IEnumerator Attack(float time)
    {
        if(!isAttacking){
            //Cooldown/Interval between every attack
            StartCoroutine(AttackCooldown(atkSpd));
            playerAnim.SetTrigger("Attack");
            //Controls the active time for hitbox
            //time = frames where we want the sword to do damage within each attack
            hitCollider.SetActive(true);
            yield return new WaitForSeconds(time);
            hitCollider.SetActive(false);
        }
    }

    //Attack Cooldown - Helps Calculate Attack Speed/Cooldown
    IEnumerator AttackCooldown(float time){
        isAttacking = true;
        yield return new WaitForSeconds(time);
        isAttacking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Take Damage and Play Hurt Animations
            //Check if Enemy Script first
            if(collision.gameObject.GetComponent<Enemy>() && !playerMovement.isInvincible){
                Enemy attacker = collision.gameObject.GetComponent<Enemy>();
                TakeDamage(attacker.attack);
            }
        }
    }

    //Invoke when player takes damage - update HP bar
    public void TakeDamage(int damage){
        health -= damage;
        hpBar.SetHealth(health, maxHealth);
        if(health <= 0){
            // Die/End Scene
            GameManager._instance.GameOver();
        }
    }

    //When picking up damage boost, the player will attack faster
    public void Boosted(float time){
        if(!isDamagedBoosted){
            StartCoroutine(BoostCooldown(time));
        }
    }
    IEnumerator BoostCooldown(float time){
        isDamagedBoosted = true;
        damageBoostIcon.SetActive(true);

        //Set the current attack speed to an enhanced version
        atkSpd = atkSpdBoost;
        yield return new WaitForSeconds(time);
        //Return to base Attack Speed
        atkSpd = baseAS;

        damageBoostIcon.SetActive(false);
        isDamagedBoosted = false;
    }
}
