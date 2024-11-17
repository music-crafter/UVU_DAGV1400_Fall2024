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
    private AudioSource audio;

    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    public void Collect()
    {
        animator.SetTrigger("CollectTrigger");
        audio.Play();
        OnCollect.Invoke(healAmount);
        playerHealth.pauseUpdates = true;
    }

    public void OnCollectionFinish()
    {
        playerHealth.pauseUpdates = false;
        Destroy(gameObject);
    }
}
