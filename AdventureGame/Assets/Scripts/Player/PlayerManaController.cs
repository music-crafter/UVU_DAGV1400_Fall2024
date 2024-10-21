using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerManaController : MonoBehaviour
{
    public SimpleIntData playerMana;
    public PlayerManaUI playerManaUI;
    public GameObject characterArt;
    
    private Animator animator;
    private int maxMana;
    
    void Start()
    {
        playerManaUI.SetMaxMana(playerMana.maxValue);
        playerManaUI.UpdateMana(playerMana.currentValue);
        animator = characterArt.GetComponent<Animator>();
        Kiwi.OnCollect += Regen;
    }

    private void Regen(int regenAmount)
    {
        playerMana.UpdateValue(regenAmount);
        playerManaUI.UpdateMana(playerMana.currentValue);
    }

    public void Cast(int castAmount)
    {
        if (!playerMana.pauseUpdates)
        {
            playerMana.UpdateValue(castAmount);
            playerManaUI.UpdateMana(playerMana.currentValue);
        }
    }
}
