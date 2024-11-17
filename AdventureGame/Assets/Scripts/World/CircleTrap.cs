using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTrap : MonoBehaviour
{
    public int damage = -1;

    private Animator animator;
    private AudioSource audio;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            animator.SetTrigger("HitTrigger");
            audio.Play();
            HandleDamage(collision.gameObject, collision.GetComponent<PlayerHealthController>());
        }
    }

    private void HandleDamage(GameObject player, PlayerHealthController playerHealthController)
    {
        playerHealthController = player.gameObject.GetComponent<PlayerHealthController>();
        playerHealthController.Damage(damage);
    }
}
