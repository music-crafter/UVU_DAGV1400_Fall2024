using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        // Handle running & idling
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        
        // Handle jumping
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
        }
        
        // Handle wall jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("WallJump");
        }
    }
}
