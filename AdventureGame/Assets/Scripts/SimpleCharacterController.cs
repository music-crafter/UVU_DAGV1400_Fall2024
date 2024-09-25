using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 2f;
    public float gravity = -9.81f;
    
    private CharacterController controller;
    private Vector3 velocity;
    private Transform thisTransform;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
    }

    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnAxis();
    }
    
    private void MoveCharacter()
    {
        // Horizontal
        var moveInput = Input.GetAxis("Horizontal");
        var move = new Vector3(moveInput, 0f, 0f) * (moveSpeed * Time.deltaTime);
        controller.Move(move);
        
        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void ApplyGravity()
    {
        // Apply gravity when not grounded
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f; // Resets velocity when grounded
        }
        // Apply velocity to controller
        controller.Move(velocity * Time.deltaTime);
    }
    
    private void KeepCharacterOnAxis()
    {
        // Maintain character's Z position
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }
}
