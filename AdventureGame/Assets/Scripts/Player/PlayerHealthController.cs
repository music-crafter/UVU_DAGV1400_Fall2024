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
        if (playerHealth.pauseUpdates)
        {
            while (hitTimer >= 0)
            {
                animator.SetTrigger("HitTrigger");
                hitTimer -= Time.deltaTime;
                if (hitTimer <= 0)
                {
                    playerHealth.pauseUpdates = false;
                    hitTimer = hitImmuneTime;
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
            playerHealth.UpdateValue(damageAmount);
            playerHealthUI.UpdateHearts(playerHealth.currentValue);
            playerHealth.pauseUpdates = true;   
        }

        if (playerHealth.currentValue <= 0)
        {
            // Player is dead, call game over function
        }
    }
}
