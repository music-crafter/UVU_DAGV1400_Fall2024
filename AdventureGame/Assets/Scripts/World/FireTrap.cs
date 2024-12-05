using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    public int damage = -1;
    
    private GameObject player;
    private PlayerHealthController playerHealth;
    private Animator animator;
    private AudioSource audioSource;
    
    public Transform triggerPos;
    public Vector2 triggerSize = new Vector2(0.5f, 0.05f);
    public LayerMask layer;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerController");
        playerHealth = player.GetComponent<PlayerHealthController>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if (Trigger()) // Can probably change to while loop
        {
            animator.SetBool("Active", true);
            HandleDamage(playerHealth);
        }
        else
        {
            animator.SetBool("Active", false);
        }
    }

    private void HandleDamage(PlayerHealthController playerHealthController)
    {
        playerHealthController.Damage(damage);
    }
    
    private bool Trigger()
    {
        return Physics2D.OverlapBox(triggerPos.position, triggerSize, 0f, layer);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(triggerPos.position, triggerSize);
    }
}
