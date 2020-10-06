using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int value;
    public int maxValue;
    public bool useClamp;

    public bool IsMaxed => value >= maxValue;

    public void AddToValue(int amount)
    {
        value += amount;
        ClampValue();
    }

    public void SetValue(int amount)
    {
        value = amount;
        ClampValue();
    }

    public void AddToMaxValue(int amount)
    {
        maxValue += amount;
        ClampValue();
    }

    public void SetMaxValue(int amount)
    {
        maxValue = amount;
        ClampValue();
    }

    public void SetValueToMax()
    {
        value = maxValue;
    }

    private void ClampValue()
    {
        if (!useClamp) return;

        if (value < 0)
        {
            value = 0;
        }
        else if (value > maxValue)
        {
            SetValueToMax();
        }
    }
}
