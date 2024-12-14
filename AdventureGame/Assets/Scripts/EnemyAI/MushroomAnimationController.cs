using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        RunAnimation();
    }

    private void RunAnimation()
    {
        if (rb.velocity.x != 0)
        {
            animator.SetTrigger("RunTrigger");
        }
        else
        {
            animator.SetTrigger("IdleTrigger");
        }
    }
}
