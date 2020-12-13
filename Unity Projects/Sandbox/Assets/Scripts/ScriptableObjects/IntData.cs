using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class IntData : ScriptableData
{
    public int value, maxValue;
    public bool useClamp, lockValue;
    
    public bool IsMaxed => value >= maxValue;

    public UnityEvent updateValueEvent, zeroEvent;

    public void AddToValue(int amount)
    {
        if (lockValue) return;
        value += amount;
        ClampValue();
    }
    public void AddToValue(IntData intData)
    {
        if (lockValue) return;
        value += intData.value;
        ClampValue();
    }

    public void SetValue(int amount)
    {
        if (lockValue) return;
        value = amount;
        ClampValue();
    }

    public void AddToMaxValue(int amount)
    {
        if (lockValue) return;
        maxValue += amount;
        ClampValue();
    }

    public void SetMaxValue(int amount)
    {
        if (lockValue) return;
        maxValue = amount;
        ClampValue();
    }

    public void SetValueToMax()
    {
        if (lockValue) return;
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

    public override bool CanBeAltered()
    {
        if (lockValue) return false;
        return !IsMaxed;
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

    public void Lock(bool enableLock)
    {
        lockValue = enableLock;
    }
}