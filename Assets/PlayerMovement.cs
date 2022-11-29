using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Purpose: Controls Player Movement
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    //Jump Values
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float fallMultiplier = 2f;
    [SerializeField] float lowJumpMultiplier = 2.5f;

    //Detection values
    bool onGround;
    bool onWall;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector2 bottomOffset, horizontalOffset;
    [SerializeField] float collisionRadius;
    [SerializeField] float slideSpeed;

    bool isFacingRight = true;

    [SerializeField] float dodgeRollForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Controls the direction that the player faces
        if(rb.velocity.x < 0 && isFacingRight)
        {
            isFacingRight = false;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if(rb. velocity.x > 0 && !isFacingRight)
        {
            isFacingRight = true;
            transform.localScale = new Vector2(1, transform.localScale.y);
        }

        //Basic Detection for wall sliding and being grounded through OverlapCircle function detecting elements with the Ground layer
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        onWall = Physics2D.OverlapCircle((Vector2)transform.position + horizontalOffset, collisionRadius, groundLayer) || 
            Physics2D.OverlapCircle((Vector2)transform.position - horizontalOffset, collisionRadius, groundLayer);

        //If the player is grabbing the wall, we want to reduce their fall speed
        if(onWall & !onGround)
        {
            WallSlide();
        }

        //Basic Horizontal Movement: Reads the horizontal input and set the rb.velocity to a product of horizontal input and set value xSpeed
        float x = Input.GetAxis("Horizontal");
        Walk(x);

        //Jump: There are two versions of jumping: short/quick jump and longer/floaty jump. This is controlled by how long the player holds the jump button
        if (Input.GetButtonDown("Jump") && onGround)
        {
            Jump();
        }
        //In general, the jump will follow the fallMultipler fallspeed. Mostly for falling from edges and long jumps
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //If the player is NOT holding down the jump button, we increase the fall speed for a snappier jump
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump")){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        //Dodge Roll - Add a force to the player and temporarily disable their collider (giving them i-frames)
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DodgeRoll();
        }
    }

    //For testing and visualizing the detection for OnWall and OnGround
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + bottomOffset);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + horizontalOffset);
    }

    //Simple Horizontal Movement based on setting speed rather than setting position, because this allows smoother flow in play
    public void Walk(float xSpeed)
    {
        rb.velocity = new Vector2(xSpeed * moveSpeed, rb.velocity.y);
    }

    //Jump Function: Initial set of the product of a basic Vector2.up and a set value of jumpSpeed
    public void Jump()
    {
        rb.velocity = Vector2.up * jumpSpeed;
    }

    //When wallsliding, the fallSpeed is controlled through a different value of slideSpeed;
    private void WallSlide()
    {
        rb.velocity = new Vector2(rb.velocity.x, -slideSpeed);
    }

    private void DodgeRoll()
    {
        rb.velocity = Vector2.zero;
        Debug.Log("Dodgeroll");
        if (isFacingRight)
        {
            Debug.Log("DR");
            rb.velocity = Vector2.right * dodgeRollForce;
        }
        else
        {
            rb.velocity = Vector2.left * dodgeRollForce;
        }
    }
}
