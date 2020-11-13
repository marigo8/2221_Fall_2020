using UnityEngine;

public class ScriptableData : ScriptableObject
{
    public string label;

    public virtual bool CanBeAltered()
    {
        return true;
    }

    public virtual string GetString()
    {
        return "not implemented";
    }

    public virtual float GetFraction()
    {
        return 1f;
    }
}
