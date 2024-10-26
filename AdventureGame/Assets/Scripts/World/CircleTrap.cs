using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTrap : MonoBehaviour
{
    public int damage = -1;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            HandleDamage(collision.gameObject, collision.GetComponent<PlayerHealthController>());
            animator.SetTrigger("HitTrigger");
        }
    }

    private void HandleDamage(GameObject player, PlayerHealthController playerHealthController)
    {
        playerHealthController = player.gameObject.GetComponent<PlayerHealthController>();
        playerHealthController.Damage(damage);
    }
}
