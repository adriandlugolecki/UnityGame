using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "touch" && collision.collider.GetType() != typeof(EdgeCollider2D))
        {
            Debug.Log("zderzenie");
            gameManager.TakeLife();
            audioSource.clip = dmg;
            audioSource.PlayOneShot(dmg);
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
