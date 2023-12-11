using UnityEngine;

public class EnemyDown : MonoBehaviour
{
    public Transform A;
    public Transform B;
    private Transform target;
    private bool isMovingToA = true;
    public float reactionRange = 3f;

    Rigidbody2D rb;
    public CharacterController2D controller;
    public Animator animator;
    private GameManager gameManager;
    public float runSpeed = 30f;
    float direction = -1f;
    float horizontalMove = 0f;

    public AudioClip dmg;
    private AudioSource audioSource;
   
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = distanceTo(target);
        if(distanceToPlayer <= reactionRange )
        {
            MoveTowardsPlayer();
        }
        else
        {
            MoveBetweenPoints();
        }
        horizontalMove = direction * runSpeed;

        
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false);

    }
    void MoveBetweenPoints()
    {

        if (isMovingToA)
        {

            MoveToPointA();
        }
        else
        {

            MoveToPointB();
        }
    }
    void MoveToPointA()
    {
        direction = -1f;
        if (distanceTo(A) < 0.1f)
        {
            isMovingToA = !isMovingToA;
            direction = 1f;

        }
    }
    void MoveToPointB()
    {
        direction = 1f;
        if (distanceTo(B) < 0.1f)
        {
            isMovingToA = !isMovingToA;
            direction = -1f;

        }
    }
    void MoveTowardsPlayer()
    {
        float value = (target.position.x - transform.position.x);
        if (value > 0 && distanceTo(B) > 0.1f)
        {
            direction = 1;
        }
        else if (value < 0 && distanceTo(A) > 0.1f)
        {
            direction = -1;
        }
        else { direction = 0; }
    }
    float distanceTo(Transform point)
    {
        return Vector2.Distance(transform.position, point.position);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Physics2D.IgnoreCollision(other.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(other.GetComponent<BoxCollider2D>(), GetComponentInChildren<EdgeCollider2D>());
            Physics2D.IgnoreCollision(other.GetComponentInChildren<BoxCollider2D>(), GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(other.GetComponentInChildren<BoxCollider2D>(), GetComponentInChildren<EdgeCollider2D>());

            audioSource.clip = dmg;
            audioSource.PlayOneShot(dmg);
            animator.SetBool("Down", true);
            gameManager.AddScore(100);

            other.transform.root.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,10);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;

            Destroy(this.gameObject, 1f);
            
        }
  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "touch")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "touch")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
}
