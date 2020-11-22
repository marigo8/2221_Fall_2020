using System;
using UnityEngine;

public class AITargetBehaviour : MonoBehaviour
{
    public int priority;

    public void CallAI(Collider other)
    {
        var ai = other.GetComponent<AIBehaviour>();
        if (ai == null) return;
        ai.AddPotentialTarget(this);
    }

    public void RemoveFromAI(Collider other)
    {
        var ai = other.GetComponent<AIBehaviour>();
        if (ai == null) return;
        ai.RemovePotentialTarget(this);
    }
}
