using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatanControler : MonoBehaviour
{
    public GameObject floor;
    private float maxSpeed = 7f;
    private float jumpHeight = 25f;
    private float satanGravity = 25f;
    private Rigidbody2D satanRB;
    private bool isOnGround;

    private float attackTimer = 0f;
    private float attackPeriod = 2f;

    // Start is called before the first frame update
    void Start()
    {
        satanRB = GetComponent<Rigidbody2D>();
        satanRB.gravityScale = satanGravity;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackPeriod) {
            attackTimer -= attackPeriod;

            //Do stuff
        }

        
    }
}
