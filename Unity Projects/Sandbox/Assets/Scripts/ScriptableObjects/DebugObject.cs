using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DebugObject : ScriptableObject
{
    public string message;

    public void Log()
    {
        Debug.Log(message);
    }
}
