using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationController : MonoBehaviour
{
    public GameObject playerController;
    public PlayerMovementController controller;
    public Rigidbody2D rb;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = playerController.GetComponent<PlayerMovementController>();
        rb = playerController.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        HandleAnimations(controller.grounded, controller.isWallSliding, controller.maxJumps, controller.jumpsRemaining, rb);
    }

    private void HandleAnimations(bool grounded, bool isWallSliding, int maxJumps, int jumpsRemaining, Rigidbody2D rb)
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
    }
}