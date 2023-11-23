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
    public Camera cam;
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
        //camera following player
        cam.transform.position = new Vector3(31.33f, -1.2f, -6.3f);
        if(playerRB.position.x > 31.21)
        {
            cam.transform.position = new Vector3(playerRB.position.x, -1.1f, -6.3f);
            if (playerRB.position.y > 0.95f)
            {
                cam.transform.position = new Vector3(playerRB.position.x, playerRB.position.y, -6.3f);
            }
        } if(playerRB.position.x > 46.86)
        {
            cam.transform.position = new Vector3(46.91f, -1.2f, -6.3f);
            if (playerRB.position.y > 1.02f)
            {
                cam.transform.position = new Vector3(46.91f, playerRB.position.y, -6.3f);
            }
        } if (playerRB.position.x <= 31.21)
        {
            if (playerRB.position.y > 1.02f)
            {
                cam.transform.position = new Vector3(31.33f, playerRB.position.y, -6.3f);
            }
        }


        moveDirection = Input.GetAxis("Horizontal");

        //Facing angle
        if (!GameManager.instance.gameIsPaused)
        {
            if (moveDirection < 0)
            {
                spriteRenderer.flipX = true;

            }
            else if (moveDirection > 0)
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
        if (isOnGround) return;

        if (collision.gameObject.CompareTag("Floor"))
        {
            var collisionDir = ((Vector2)transform.position - collision.GetContact(0).point).normalized;
            if(collisionDir.y > 0.5f)
                isOnGround = true;
        }
    }
}
