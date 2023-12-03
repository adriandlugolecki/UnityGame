using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDown : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    private bool down = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            down = true;
            Debug.Log("down");

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.MovePosition(new Vector2(transform.position.x, transform.position.y+2));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (down)
        {
            animator.SetBool("Down", true);
            
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            Destroy(this.gameObject,2f);
 
        }
    }
}
