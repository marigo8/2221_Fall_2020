using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class IntData : ScriptableData
{
    public int value;
    public int maxValue;
    public int startValue;
    public int startMax;
    public bool useClamp, useStartValues;

    public UnityEvent zeroEvent;

    public bool IsMaxed => value >= maxValue;

    private void OnEnable()
    {
        if (!useStartValues) return;
        value = startValue;
        maxValue = startMax;
    }

    public void AddToValue(int amount)
    {
        value += amount;
        ClampValue();
        if (value <= 0)
        {
            zeroEvent.Invoke();
        }
    }
    public void AddToValue(IntData intData)
    {
        value += intData.value;
        ClampValue();
        if (value <= 0)
        {
            zeroEvent.Invoke();
        }
    }

    public void SetValue(int amount)
    {
        value = amount;
        ClampValue();
        if (value <= 0)
        {
            zeroEvent.Invoke();
        }
    }

    public void AddToMaxValue(int amount)
    {
        maxValue += amount;
        ClampValue();
        if (value <= 0)
        {
            zeroEvent.Invoke();
        }
    }

    public void SetMaxValue(int amount)
    {
        maxValue = amount;
        ClampValue();
        if (value <= 0)
        {
            zeroEvent.Invoke();
        }
    }

    public void SetValueToMax()
    {
        value = maxValue;
        if (value <= 0)
        {
            zeroEvent.Invoke();
        }
    }

    private void ClampValue()
    {
        if (!useClamp) return;

        value = Mathf.Clamp(value, 0, maxValue);
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