using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 velocity;
    private float maxSpeed = 10f;
    private float jumpHeight = 26f;
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
    public Sprite jesusAttack;
    private float jesusWalkAnimationTimer = 0f;
    private float animationTime = 0.1f;
    //attack
    public Transform attackPoint;
    private float attackRange = 0.5f;
    public LayerMask enemyLayer;
    private float attackTimer = 0;
    private float maxAttackPerSec = 0.5f;
    
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
        cam.transform.position = new Vector3(31.33f, 0f, -6.3f);
        if(playerRB.position.x > 31.21)
        {
            cam.transform.position = new Vector3(playerRB.position.x, 0f, -6.3f);
            if (playerRB.position.y > 0.95f)
            {
                cam.transform.position = new Vector3(playerRB.position.x, playerRB.position.y, -6.3f);
            }
        } if(playerRB.position.x > 46.86)
        {
            cam.transform.position = new Vector3(46.91f, 0f, -6.3f);
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
        //boss arena coordinates
        if(playerRB.position.x > 62.3f && playerRB.position.y > 20.02f)
        {
            cam.transform.position = new Vector3(81.23f, 26f, -6.3f);
        }


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

        attackTimer += Time.deltaTime;
        //attack
        if (attackTimer < 0.4)
        {
            spriteRenderer.sprite = jesusAttack;
        }
        if (Input.GetKeyDown(KeyCode.Space) && attackTimer > maxAttackPerSec)
        {
            attackTimer = 0;
            attack();
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

    void attack()
    {
        //attack animation
        spriteRenderer.sprite = jesusWalk1;

        //collision
        if (spriteRenderer.flipX == false)
        {
            attackPoint.transform.position = new Vector2(playerRB.position.x + 1.1f, playerRB.position.y);
        }
        else
        {
            attackPoint.transform.position = new Vector2(playerRB.position.x - 1.1f, playerRB.position.y);
        }

        //detect range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // Damage enemy
            enemy.gameObject.GetComponent<EnemyHealth>().takeDMG();
            if (enemy.gameObject.GetComponent<EnemyHealth>().getHP() == 0)
            {
                Destroy(enemy.gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
