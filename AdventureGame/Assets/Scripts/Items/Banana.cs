using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Banana : MonoBehaviour, IItem
{
    public SimpleIntData playerScore;
    public UnityEvent onCollect;
    
    private PlayerScoreUI playerScoreUI;
    private Animator animator;
    private AudioSource audio;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerScoreUI = FindObjectOfType<PlayerScoreUI>();
        audio = GetComponent<AudioSource>();
    }

    public void Collect()
    {
        animator.SetTrigger("CollectTrigger");
        audio.Play();
        onCollect.Invoke();
        playerScoreUI.UpdatePlayerScore();
        playerScore.pauseUpdates = true;
    }

    public void OnCollectionFinish()
    {
        playerScore.pauseUpdates = false;
        Destroy(gameObject);
    }
}
