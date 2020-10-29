using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class FloatData : ScriptableData
{
    public float value, maxValue, startValue, startMax;
    public bool useClamp;

    public bool IsMaxed => value >= maxValue;

    public UnityEvent zeroEvent;
    
    private void OnEnable()
    {
        if (!useStartingValue) return;
        value = startValue;
        maxValue = startMax;
    }

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

        value = Mathf.Clamp(value, 0, maxValue);
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
