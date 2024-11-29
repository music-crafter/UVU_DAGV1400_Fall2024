using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider2D))]
public class DamageParticle : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public int particleAmount = 10;
    
    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerController"))
        {
            particleSystem.Emit(particleAmount);
        }
    }
}
