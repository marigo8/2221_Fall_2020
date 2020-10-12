using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatDebugLog : ScriptableObject
{
    public List<float> log = new List<float>();

    public void AddToLog(float value)
    {
        log.Add(value);
    }
}
