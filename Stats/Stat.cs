using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private BarScript bar;
    private float maxValue;
    private float currentValue;

    public float MaxValue
    {
        get
        {
            return maxValue;
        }

        set
        {
            maxValue = baseValue;
            bar.MaxValue = maxValue;
        }
    }

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            this.currentValue = value;
            bar.Value = currentValue;
        }
    }
    [SerializeField]
    public int baseValue;

    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}