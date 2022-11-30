using UnityEngine;
using System.Collections;

//Basic Enemy Movement - The enemy will patrol in back and forth motion regardless of player position.
public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool isFacingRight = true;
    [SerializeField] Vector2 detectOffset;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float moveSpeed;
    Animator enemyAnim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        //If the enemy intends to go right
        if (isFacingRight)
        {
            //First, we check if it is possible to move right
            if (Physics2D.OverlapCircle((Vector2)transform.position + detectOffset, 0.1f, groundLayer))
            {
                isFacingRight = false;
                Flip();
            }
            //If so, we set rb.velocity to the moveSpeed to the right
            else
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
        }
        //If the enemy intends to go left, the code is the same as the right intentions but we alter in order to check/move left
        else if (!isFacingRight)
        {
            if (Physics2D.OverlapCircle((Vector2)transform.position - detectOffset, 0.1f, groundLayer))
            {
                isFacingRight = true;
                Flip();
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
        }

        //Set the enemy to walk
        enemyAnim.SetBool("IsWalking", rb.velocity.x != 0);
    }

    //Flip the sprite horizontally
    void Flip(){
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}

