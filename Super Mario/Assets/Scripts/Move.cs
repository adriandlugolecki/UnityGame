using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    
    public CharacterController2D controller;
    public Animator animator;
    private float runSpeed = 40f;
    bool jump = false;
    bool onGround;
    float horizontalMove = 0f;
    float time=0f;
    public Text boost;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
       
        if (Input.GetButtonDown("Jump") && onGround)
        {
            
            jump = true;
            animator.SetBool("IsJumping", true);
            onGround = false;
        }
    }
    
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;

        if (time != 0f)
        {
            boost.text = "Boost: " + time.ToString();
            time--;
            Debug.Log(runSpeed);
        }
        else
        {
            boost.text = "";
            runSpeed = 40f;
        }
    }

    public void OnLanding()
    {
        onGround = true;
        animator.SetBool("IsJumping", false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "star")
        {
            time = 200f;
            runSpeed = 60f;
            Destroy(collision.gameObject);

        }
    }
}
