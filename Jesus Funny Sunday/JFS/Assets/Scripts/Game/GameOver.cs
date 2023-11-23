using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    private ParticleSystem blood;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        blood = GameObject.Find("Blood Explosion").GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OutOfBounds") || collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.UpdateLives(-1);

            blood.transform.position = gameObject.transform.position;

            blood.Play();

            Destroy(gameObject);
        }
    }
}
