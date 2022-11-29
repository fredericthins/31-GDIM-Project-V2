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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
        }
    }
}

