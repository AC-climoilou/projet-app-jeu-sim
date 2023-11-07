using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 velocity;
    private float maxSpeed = 10f;
    private float jumpHeight = 25f;
    private float playerGravity = 7f;
    private float moveDirection;
    private Rigidbody2D playerRB;
    private bool isOnGround;
    private SpriteRenderer spriteRenderer;
    public Sprite jesusIdle;
    public Sprite jesusWalk1;
    public Sprite jesusWalk2;
    public Sprite jesusJump;
    private float jesusWalkAnimationTimer = 0f;
    private float animationTime = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.gravityScale = playerGravity;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");

        //Facing angle
        if (moveDirection < 0)
        {
            spriteRenderer.flipX = true;
            
        } else if (moveDirection > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (moveDirection != 0 && isOnGround)
        {
            jesusWalkAnimationTimer += Time.deltaTime;

            if (jesusWalkAnimationTimer >= animationTime)
            {
                jesusWalkAnimationTimer = 0.0f;

                if (spriteRenderer.sprite == jesusWalk1)
                {
                    spriteRenderer.sprite = jesusWalk2;
                }
                else
                {
                    spriteRenderer.sprite = jesusWalk1;
                }
            }
        }
        else if (isOnGround)
        {
            spriteRenderer.sprite = jesusIdle;
        }

        //jump
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            isOnGround = false;
            playerRB.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            spriteRenderer.sprite = jesusJump;
        }
    }

    void FixedUpdate()
    {
        //movement
        if(isOnGround)
        {
            velocity = new Vector2(moveDirection * maxSpeed, playerRB.velocity.y);
        }
        else velocity = new Vector2(moveDirection * maxSpeed / 1.5f, playerRB.velocity.y);
        
        playerRB.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnGround = true;
        }
    }
}
