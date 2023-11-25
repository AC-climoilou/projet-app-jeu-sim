using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    private GameObject player;
    public Transform projPoisition;
    private float timer;
    private int range = 20;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < range)
            {
                timer += Time.deltaTime;
                if (timer > 2)
                {
                    timer = 0f;
                    shoot();
                }
            }
        }
        
    }

    void shoot()
    {
        Instantiate(projectile, projPoisition.position, Quaternion.identity);
    }
}
