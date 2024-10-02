using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [Header ("Animation")]
    public Rigidbody2D rb;
    public Animator animator;
    
    [Header ("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;
    
    private bool isFacingRight = true;
    private bool grounded;
    
    void Start()
    {

    }
    
    void Update()
    {
        HandleAnimations();
        Flip();
        GroundCheck();
    }

    private void HandleAnimations()
    {
        if (rb.velocity.y > 0.01 && Input.GetButtonDown("Jump")) // Jump & Fall
        {
            animator.SetTrigger("JumpTrigger");
        } 
        else if (rb.velocity.y < -0.01)
        {
            animator.SetTrigger("FallTrigger");
        }
        else if (rb.velocity.x != 0 && grounded) // Run & Idle
        {
            animator.SetTrigger("RunTrigger");
        }
        else if (rb.velocity.x == 0 && grounded)
        {
            animator.SetTrigger("IdleTrigger");
        }
    }
    
    private void Flip()
    {
        if (isFacingRight && Input.GetAxis("Horizontal") < 0 || !isFacingRight && Input.GetAxis("Horizontal") > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1;
            transform.localScale = ls;
        }
    }
    
    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0f, groundLayer))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
}
