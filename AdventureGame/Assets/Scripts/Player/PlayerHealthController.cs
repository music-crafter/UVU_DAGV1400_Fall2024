using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth = 3;
    public PlayerHealthUI playerHealthUI;
    public GameObject characterArt;
    private Animator animator;
    
    private int currentHealth;
    private float hitTimer;
    private float hitImmuneTime = 0.6f;
    private bool hitImmune;
    
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthUI.SetMaxHearts(maxHealth);
        hitTimer = hitImmuneTime;
        animator = characterArt.GetComponent<Animator>();
        Apple.OnCollect += Heal;
    }

    void Update()
    {
        if (hitImmune)
        {
            while (hitTimer >= 0)
            {
                animator.SetTrigger("HitTrigger");
                hitTimer -= Time.deltaTime;
                if (hitTimer <= 0)
                {
                    hitImmune = false;
                    hitTimer = hitImmuneTime;
                    break;
                }
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Trap trap = collision.GetComponent<Trap>();

        if (trap && trap.damage > 0 && !hitImmune)
        {
            Damage(trap.damage);
        }
    }

    private void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        playerHealthUI.UpdateHearts(currentHealth);
    }

    private void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        playerHealthUI.UpdateHearts(currentHealth);
        hitImmune = true;

        if (currentHealth <= 0)
        {
            // Player is dead, call game over function
        }
    }
}
