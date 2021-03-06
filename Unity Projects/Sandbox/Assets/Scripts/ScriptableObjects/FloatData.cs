﻿using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class FloatData : ScriptableData
{
    public float value, maxValue;
    public bool useClamp;

    public bool IsMaxed => value >= maxValue;

    public UnityEvent updateValueEvent, zeroEvent;

    public void AddToValue(float amount)
    {
        value += amount;
        ClampValue();
    }

    public void AddToValue(FloatData data)
    {
        AddToValue(data.value);
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

    public void SetValueFromRotationY(Transform transformObj)
    {
        value = transformObj.eulerAngles.y;
        ClampValue();
    }

    public void SetRotationYFromValue(Transform transformObj)
    {
        var rotation = transformObj.eulerAngles;
        rotation.y = value;
        transformObj.eulerAngles = rotation;
    }

    public void AddDeltaTime(float modifier)
    {
        AddToValue(Time.deltaTime * modifier);
    }

    public void AddDeltaTime(FloatData modifier)
    {
        AddDeltaTime(modifier.value);
    }

    public override bool CanBeAltered()
    {
        return !IsMaxed;
    }

    public override string GetString()
    {
        var text = label + ": " + value.ToString("F1");
        if (useClamp)
        {
            text += " / " + maxValue.ToString("F1");
        }

        return text;
    }

    public override float GetFraction()
    {
        return value / maxValue;
    }
}
