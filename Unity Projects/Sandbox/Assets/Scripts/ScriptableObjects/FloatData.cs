using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableData
{
    public float value;
    public float maxValue;
    public bool useClamp;

    public bool IsMaxed => value >= maxValue;

    public void AddToValue(float amount)
    {
        value += amount;
        ClampValue();
    }

    public void SetValue(float amount)
    {
        value = amount;
        ClampValue();
    }

    public void AddToMaxValue(float amount)
    {
        maxValue += amount;
        ClampValue();
    }

    public void SetMaxValue(float amount)
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
