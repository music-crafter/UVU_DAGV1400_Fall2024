using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwi : MonoBehaviour, IItem
{
    public int regenAmount = 2;
    public static event Action<int> OnCollect;
    
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Collect()
    {
        animator.SetTrigger("CollectTrigger");
        OnCollect.Invoke(regenAmount);
    }

    public void OnCollectionFinish()
    {
        Destroy(gameObject);
    }
}
