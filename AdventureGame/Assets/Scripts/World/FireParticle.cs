using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider2D))]
public class FireParticle : MonoBehaviour
{
    public int triggerEmissionAmount = 10;
    public int fireEmissionAmount = 20;
    public int smokeEmissionAmount = 30;
    public float emissionDelay = 0.5f;
    
    private ParticleSystem particleSystem;
    
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerController"))
        {
            StartCoroutine(EmitParticleCoroutine());
        }
    }

    private IEnumerator EmitParticleCoroutine()
    {
        particleSystem.Emit(triggerEmissionAmount);
        yield return new WaitForSeconds(emissionDelay);
        
        particleSystem.Emit(fireEmissionAmount);
        yield return new WaitForSeconds(emissionDelay);
        
        particleSystem.Emit(smokeEmissionAmount);
    }
}
