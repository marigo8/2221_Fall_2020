using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class IntData : ScriptableData
{
    public int value, maxValue;
    public bool useClamp;
    
    public bool IsMaxed => value >= maxValue;

    public UnityEvent updateValueEvent, zeroEvent;

    public void AddToValue(int amount)
    {
        value += amount;
        ClampValue();
    }
    public void AddToValue(IntData intData)
    {
        value += intData.value;
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
        SetValue(maxValue);
    }

    private void ClampValue()
    {
        if (useClamp)
        {
            value = Mathf.Clamp(value, 0, maxValue);

            if (value <= 0)
            {
                zeroEvent.Invoke();
            }
        }
        updateValueEvent.Invoke();
    }

    public override string GetString()
    {
        var text = label + ": " + value;
        if (useClamp)
        {
            text += " / " + maxValue;
        }

        return text;
    }
    
    public override float GetFraction()
    {
        return (value * 1f) / (maxValue * 1f);
    }
}