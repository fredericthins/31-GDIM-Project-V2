using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Purpose: Control animations and mechanisms of attacking and being attacked
public class PlayerCombat : MonoBehaviour
{
    //For our attack, the script will use a collider element in order to represent the "weapon"
    [SerializeField] GameObject hitCollider;
    [SerializeField] float atkSpd;
    [SerializeField] int health;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(Attack(atkSpd));
        }
    }

    //Attack will enable the "weapon" hurtbox for the atkSpeed value.
    IEnumerator Attack(float time)
    {
        hitCollider.SetActive(true);
        yield return new WaitForSeconds(time);
        hitCollider.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Take Damage and Play Hurt Animations
        }
    }


}
