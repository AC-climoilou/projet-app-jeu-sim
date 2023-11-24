using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    public AudioClip gameOverSound;
    private AudioSource cameraAudio;
    
    private ParticleSystem blood;
    public GameObject scream;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        blood = GameObject.Find("Blood Explosion").GetComponent<ParticleSystem>();

        cameraAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OutOfBounds") || collision.gameObject.CompareTag("Enemy"))
        {
            scream.GetComponent<AudioSource>().volume = GameSettings.SoundVolume;
            Instantiate(scream, transform.position, Quaternion.identity);

            GameManager.instance.UpdateLives(-1);

            blood.transform.position = gameObject.transform.position;

            if(GameSettings.ObjectParticles == true)
            {
                blood.Play();
            }
            
            cameraAudio.clip = gameOverSound;
            cameraAudio.volume = GameSettings.SoundVolume;
            cameraAudio.Play();

            Destroy(gameObject);
        }
    }
}
