using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Vector3GameAction : ScriptableObject
{
    public UnityAction<Vector3> action;

    public void Raise(Vector3 vector)
    {
        action?.Invoke(vector);
    }

    public void RaiseFromTransform(Transform transformObj)
    {
        Raise(transformObj.position);
    }
}
