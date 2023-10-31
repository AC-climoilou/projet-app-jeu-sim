using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float maxSpeed = 7f;
    private float jumpHeight = 25f;
    private float playerGravity = 7f;
    private float moveDirection;
    private Rigidbody2D playerRB;
    private bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.gravityScale = playerGravity;

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");

        //Facing angle
        if (moveDirection < 0)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        } else if (moveDirection > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        //jump
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            isOnGround = false;
            playerRB.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        //movement
        Vector2 velocity = new Vector2(moveDirection * maxSpeed, playerRB.velocity.y);
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
