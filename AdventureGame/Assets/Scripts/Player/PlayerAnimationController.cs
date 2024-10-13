using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerAnimationController : MonoBehaviour
{
    public GameObject playerController;
    public PlayerMovementController movementController;
    public Rigidbody2D rb;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        movementController = playerController.GetComponent<PlayerMovementController>();
        rb = playerController.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        HandleAnimations(movementController.grounded, movementController.isWallSliding, rb);
    }

    private void HandleAnimations(bool grounded, bool isWallSliding, Rigidbody2D rb)
    {
        // Idling & Running
        if (Input.GetAxis("Horizontal") == 0 && grounded)
        {
            animator.SetTrigger("IdleTrigger");
        }
        else if (Input.GetAxis("Horizontal") != 0 && !isWallSliding && grounded)
        {
            animator.SetTrigger("RunTrigger");
        }
        
        // Jumping & Double Jumping
        if (Input.GetButtonDown("Jump") && !grounded)
        {
            animator.SetTrigger("DoubleJumpTrigger");
        }
        else if (Input.GetButtonDown("Jump") && grounded)
        {
            animator.SetTrigger("JumpTrigger");
        }
        
        // Wall Sliding
        if (isWallSliding)
        {
            animator.SetTrigger("WallSlideTrigger");
        }

        // Falling
        if (rb.velocity.y < -0.01)
        {
            animator.SetTrigger("FallTrigger");
        }
        else if (grounded)
        {
            animator.SetTrigger("FallCancel");
        }
    }
}