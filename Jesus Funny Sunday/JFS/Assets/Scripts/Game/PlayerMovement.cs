using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject player;
    public Camera mainCamera;
    private float maxSpeed = 7f;
    private float gravityForce = 1.0f;
    private float jumpHeight = 10.0f;
    private bool facingRight = true;
    private float moveDirection;
    private bool isGrounded = true;
    private Rigidbody2D rb;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rb.freezeRotation = true;
        moveDirection = Input.GetAxis("Horizontal");

        //camera follow player

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");

        //facing angle
        if (moveDirection < 0)
        {
            facingRight = false;
            GetComponent<SpriteRenderer>().color = Color.green;
        } else
        {
            facingRight = true;
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        //movement
        if (isGrounded)
        {
            transform.Translate(Vector2.right * maxSpeed * moveDirection * Time.deltaTime);
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.Translate(Vector2.up * jumpHeight * Time.deltaTime);
            }
        } else
        {
            transform.Translate(Vector2.right * (maxSpeed / 2f) * moveDirection * Time.deltaTime);
        }
    }


}
