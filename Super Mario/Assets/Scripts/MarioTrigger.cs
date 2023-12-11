using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MarioTrigger : MonoBehaviour
{
    private GameManager gameManager;
    public AudioClip dmg;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "touch" && collision.collider.GetType() != typeof(EdgeCollider2D))
        {
            gameManager.TakeLife();
            audioSource.clip = dmg;
            audioSource.PlayOneShot(dmg);
            float value = (transform.position.x - collision.gameObject.transform.position.x);
            if(value > 0)
            {
                transform.root.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(50, 2);
            }
            else
            {
                transform.root.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-50, 2);
            }
            
        }
        if (collision.gameObject.tag == "EndFlag")
        {
            gameManager.EndGame();
        }
        if(collision.gameObject.tag == "void")
        {
            gameObject.SetActive(false);
            gameManager.TakeAllLife();
        }
    }
}
