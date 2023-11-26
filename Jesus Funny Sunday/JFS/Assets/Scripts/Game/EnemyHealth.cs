using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int HP = 2;
    private float timeDamageIndication = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeDamageIndication += Time.deltaTime;
        if (timeDamageIndication > 0.4)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            timeDamageIndication = 0;
        }
    }

    public void takeDMG()
    {
        HP -= 1;
        timeDamageIndication = 0;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public int getHP()
    {
        return HP;
    }
}
