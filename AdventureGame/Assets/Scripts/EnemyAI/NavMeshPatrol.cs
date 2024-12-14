using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrol : MonoBehaviour
{
    public Transform[] targets;
    
    private NavMeshAgent agent;
    private SpriteRenderer sprite;
    private int currentTarget;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        agent.updateRotation = false;
        if (targets.Length > 0)
        {
            agent.SetDestination(targets[0].position);
        }
    }
    
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            currentTarget = (currentTarget + 1) % targets.Length;
            agent.SetDestination(targets[currentTarget].position);
            sprite.flipX = !sprite.flipX;
        }
    }
}
