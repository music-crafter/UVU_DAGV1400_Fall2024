using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerScoreUI : MonoBehaviour
{
    public SimpleIntData playerScore;
    
    private TextMeshProUGUI text;
    private Animator animator;
    
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
        UpdatePlayerScore();
    }

    public void UpdatePlayerScore()
    {
        text.text = playerScore.currentValue.ToString();
        animator.SetTrigger("PlayerScoreTrigger");
    }
}
