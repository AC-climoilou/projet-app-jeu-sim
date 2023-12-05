using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemy_tete : MonoBehaviour
{
    private Rigidbody2D rigidBody; 

    [SerializeField]
    private float distanceMouvement;

    [SerializeField]
    private float vitesse;

    private float xStart;

    private float xEnd;

    private bool avanceVersLaDroite;

    private bool debutChangementDirection;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        avanceVersLaDroite = true;
        debutChangementDirection = true;
        xStart = transform.position.x;
        xEnd = transform.position.x + distanceMouvement;
    }

    // Update is called once per frame
    void Update()
    {
        if (avanceVersLaDroite && transform.position.x > xEnd)
        {
            avanceVersLaDroite = false;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            debutChangementDirection = true;
        }
        else if (!avanceVersLaDroite && transform.position.x < xStart)
        {
            avanceVersLaDroite = true;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            debutChangementDirection = true;
        }

        if (avanceVersLaDroite && debutChangementDirection )
        {
            rigidBody.velocity = new Vector2(vitesse, 0);
            debutChangementDirection = false;
        }
        else if (!avanceVersLaDroite && debutChangementDirection )
        {
            rigidBody.velocity = new Vector2(-vitesse, 0);
            debutChangementDirection = false;
        }
    }
}
