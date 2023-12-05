using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDown : MonoBehaviour
{
    public int howFar = 2;
    private GameManager gameManager;
    private Rigidbody2D rb;
    private Vector2 velocity;
    public Animator animator;
    private bool down = false;
    private Vector2 positionZero;
    private Vector2 target;
    private bool left;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(-2,0);
        positionZero = rb.transform.position;
        target = new Vector2(positionZero.x-howFar,positionZero.y);

        gameManager = GameManager.Instance;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (down)
        {
            animator.SetBool("Down", true);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            
            

            Destroy(this.gameObject,1f);
 
        }
    }
    private void FixedUpdate()
    {
        if (!down)
        {
            if (!left)
            {
                float dist = Vector2.Distance(rb.position, target);
                if (dist < 0.1)
                {
                    velocity = velocity*(-1);
                    left = true;
                }
            }
            else
            {
                float dist = Vector2.Distance(rb.position, positionZero);
                if (dist < 0.1)
                {
                    velocity = velocity * (-1);
                    left = false;
                }
            }
            
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            down = true;
            gameManager.AddScore(100);
        }
            

        
    }
}
