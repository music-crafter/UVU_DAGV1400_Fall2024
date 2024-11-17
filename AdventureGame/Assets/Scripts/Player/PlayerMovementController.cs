using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public AudioSource jumpAudioSource;
    
    [Header ("Movement")]
    public float moveSpeed = 7f;
    
    private bool isFacingRight = true;
    private float horizontalMovement;
    
    [Header("Jump")]
    public float jumpStrength = 15f;
    public int maxJumps = 2;
    public int jumpsRemaining;
    
    [Header ("WallMovement")]
    public float wallSlideSpeed = 5f;
    public Vector2 wallJumpStrength = new Vector2(5f, 15f);
    
    public bool isWallSliding;
    private bool isWallJumping;
    private float wallJumpDirection;
    private float wallJumpTime = 1f;
    private float wallJumpTimer;
    
    [Header("Gravity")]
    public float baseGravity = 2.2f;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;
    
    [Header ("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;
    
    public bool grounded;
    
    [Header ("WallCheck")]
    public Transform wallCheckPos;
    public Vector2 wallCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask wallLayer;
    
    private void Start()
    {
        //jumpAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        WallSlide();
        WallJump();
        GroundCheck();
        Gravity();

        if (!isWallJumping)
        {
            MoveCharacter();
            Flip();
        }
    }
    
    public void Gravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier; // Accelerate when falling
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpsRemaining > 0)
        {
            jumpAudioSource.Play();
            // Full height jump
            if (context.performed)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
                jumpsRemaining--;
            }
            // Short hop
            else if (context.canceled)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                jumpsRemaining--;
            }
        }
        
        // Wall Jump
        if (context.performed && wallJumpTimer > 0f)
        {
            jumpAudioSource.Play();
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpDirection * wallJumpStrength.x, wallJumpStrength.y);
            wallJumpTimer = 0;
            
            // Force flip
            if (transform.localScale.x != wallJumpDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 ls = transform.localScale;
                ls.x *= -1;
                transform.localScale = ls;
            }
            
            Invoke(nameof(CancelWallJump), wallJumpTime);
        }
    }
    
    private void MoveCharacter()
    {
        // Horizontal
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
    }

    private void WallSlide()
    {
        if (!grounded && WallCheck() && horizontalMovement != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -wallSlideSpeed));
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpDirection = -transform.localScale.x;
            wallJumpTimer = wallJumpTime;
            
            CancelInvoke(nameof(CancelWallJump));
        }
        else if (wallJumpTimer > 0)
        {
            wallJumpTimer -= Time.deltaTime;
        }
    }

    private void CancelWallJump()
    {
        isWallJumping = false;
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
            jumpsRemaining = maxJumps;
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    private bool WallCheck()
    {
        return Physics2D.OverlapBox(wallCheckPos.position, wallCheckSize, 0f, wallLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(wallCheckPos.position, wallCheckSize);
    }
}
