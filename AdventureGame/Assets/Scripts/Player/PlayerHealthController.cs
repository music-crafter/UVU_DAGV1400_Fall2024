using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public SimpleIntData playerHealth;
    public PlayerHealthUI playerHealthUI;
    public GameObject characterArt;
    
    private Animator animator;
    private int maxHealth;
    private float hitTimer;
    private float hitImmuneTime = 0.6f;
    private bool startHitTimer;
    
    void Start()
    {
        playerHealthUI.SetMaxHearts(playerHealth.maxValue);
        playerHealthUI.UpdateHearts(playerHealth.currentValue);
        hitTimer = hitImmuneTime;
        animator = characterArt.GetComponent<Animator>();
        Apple.OnCollect += Heal;
    }

    void Update()
    {
        if (startHitTimer)
        {
            while (hitTimer >= 0)
            {
                hitTimer -= Time.deltaTime;
                if (hitTimer <= 0)
                {
                    playerHealth.pauseUpdates = false;
                    hitTimer = hitImmuneTime;
                    startHitTimer = false;
                    break;
                }
            }
        } 
    }

    private void Heal(int healAmount)
    {
        playerHealth.UpdateValue(healAmount);
        playerHealthUI.UpdateHearts(playerHealth.currentValue);
    }

    public void Damage(int damageAmount)
    {
        if (!playerHealth.pauseUpdates)
        {
            animator.SetTrigger("HitTrigger");
            playerHealth.UpdateValue(damageAmount);
            playerHealthUI.UpdateHearts(playerHealth.currentValue);
            playerHealth.pauseUpdates = true;
            startHitTimer = true;
        }

        if (playerHealth.currentValue <= 0)
        {
            // Player is dead, call game over function
        }
    }
}
