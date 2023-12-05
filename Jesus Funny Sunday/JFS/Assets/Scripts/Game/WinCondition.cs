using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private int done = 0;
    private GameObject poudre;
    // Start is called before the first frame update
    void Start()
    {
        poudre = GameObject.FindGameObjectWithTag("Poudre");
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
    }

    void checkHealth()
    {
        if (GameObject.Find("Satan") == null && done == 0)
        {
            spawnPowder();
        }
    }

    void spawnPowder()
    {
        done = 1;
        BoxCollider2D bc = poudre.GetComponent<BoxCollider2D>();
        bc.transform.position = new Vector3(bc.transform.position.x, 19.80f, bc.transform.position.y);
    }
}
