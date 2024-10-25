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

    void Start()
    {
        animator = GetComponent<Animator>();
        playerScoreUI = FindObjectOfType<PlayerScoreUI>();
    }

    public void Collect()
    {
        animator.SetTrigger("CollectTrigger");
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
