using UnityEngine;
using UnityEngine.Events;

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

        value = Mathf.Clamp(value, 0, maxValue);
    }

    public void SetValueFromRotationY(Transform transformObj)
    {
        value = transformObj.eulerAngles.y;
        ClampValue();
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
