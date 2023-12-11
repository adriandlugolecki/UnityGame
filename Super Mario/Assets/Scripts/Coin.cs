using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coin;
    private AudioSource audioSource;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            audioSource.Play();
            Destroy(gameObject,0.3f);
            gameManager.AddScore(200);
        }
    }
}
