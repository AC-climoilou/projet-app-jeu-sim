using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatanControler : MonoBehaviour
{
    public GameObject floor;
    private float gravity = 30f;
    private float jumpHeight = 100f;
    private Rigidbody2D satanRB;
    private Vector2 coordinates;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        satanRB = GetComponent<Rigidbody2D>();
        satanRB.gravityScale = gravity;
        //satanRB.gravityScale = satanGravity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            jumpToTarget();
        }
    }

    void jumpToTarget()
    {
        coordinates = new Vector2(Random.Range(68.4f, 92.8f), 21.2f);
        Vector2 direction = (coordinates - (Vector2)transform.position).normalized;
        satanRB.AddForce(Vector2.up * 20000);
        satanRB.AddForce(direction * jumpHeight, ForceMode2D.Impulse);
        timer = 0f;
    }
}
