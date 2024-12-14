using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = -1;

    //private AudioSource audio;
    
    private void Start()
    {
        //audio = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            //audio.Play();
            HandleDamage(collision.gameObject, collision.GetComponent<PlayerHealthController>());
        }
    }

    private void HandleDamage(GameObject player, PlayerHealthController playerHealthController)
    {
        playerHealthController = player.gameObject.GetComponent<PlayerHealthController>();
        playerHealthController.Damage(damage);
    }
}
