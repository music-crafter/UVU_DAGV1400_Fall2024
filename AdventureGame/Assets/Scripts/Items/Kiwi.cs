using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwi : MonoBehaviour, IItem
{
    public SimpleIntData playerMana;
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
        playerMana.pauseUpdates = true;
    }

    public void OnCollectionFinish()
    {
        playerMana.pauseUpdates = false;
        Destroy(gameObject);
    }
}
