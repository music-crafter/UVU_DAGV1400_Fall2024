using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    public Rigidbody2D rb;
    
    [Header ("Movement")]
    public float moveSpeed = 5f;
    
    [Header("Jump")]
    public float jumpStrength = 2f;
    public int maxJumps = 2;
    private int jumpsRemaining;
    
    [Header("Gravity")]
    public float baseGravity = 2f;
    public float maxFallSpeed = 1f;
    public float fallSpeedMultiplier = 2f;
    
    [Header ("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    private float horizontalMovement;
    
    private void Start()
    {

    }

    private void Update()
    {
        MoveCharacter();
        GroundCheck();
        Gravity();
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
    }
    
    private void MoveCharacter()
    {
        // Horizontal
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
    }
    
    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0f, groundLayer))
        {
            jumpsRemaining = maxJumps;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
