using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerManaUI : MonoBehaviour
{
    public Image mana;
    public Sprite fullManaSprite;
    public Sprite emptyManaSprite;
    
    private List<Image> manaBars = new List<Image>();

    public void SetMaxMana(int maxMana)
    {
        foreach (Image mana in manaBars)
        {
            Destroy(mana.gameObject);
        }
        
        manaBars.Clear();

        for (int i = 0; i < maxMana; i++)
        {
            Image newMana = Instantiate(mana, transform);
            newMana.sprite = fullManaSprite;
            manaBars.Add(newMana);
        }
    }

    public void UpdateMana(int currentMana)
    {
        for (int i = 0; i < manaBars.Count; i++)
        {
            if (i < currentMana)
            {
                manaBars[i].sprite = fullManaSprite;
            }
            else
            {
                manaBars[i].sprite = emptyManaSprite;
            }
        }
    }
}
