using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Apple : MonoBehaviour, IItem
{
    public SimpleIntData playerHealth;
    public int healAmount = 1;
    public static event Action<int> OnCollect;
    
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Collect()
    {
        animator.SetTrigger("CollectTrigger");
        OnCollect.Invoke(healAmount);
        playerHealth.pauseUpdates = true;
    }

    public void OnCollectionFinish()
    {
        playerHealth.pauseUpdates = false;
        Destroy(gameObject);
    }
}
