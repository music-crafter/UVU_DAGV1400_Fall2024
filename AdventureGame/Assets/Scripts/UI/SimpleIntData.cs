using UnityEngine;

[CreateAssetMenu(menuName = "Single Variables/SimpleIntData")]
public class SimpleIntData : ScriptableObject
{
    public int maxValue;
    public int currentValue;
    public bool pauseUpdates;

    public void UpdateValue(int amount)
    {
        if (!pauseUpdates)
        {
            currentValue += amount;
            if (currentValue > maxValue)
            {
                currentValue = maxValue;
            }
        }
    }

    public void SetValue(int amount)
    {
        currentValue = amount;
    }
}
