using System;
using UnityEngine;

public class AITargetBehaviour : MonoBehaviour
{
    public int priority;
    
    public void CallAI(AIBehaviour ai)
    {
        ai.AddPotentialTarget(this);
    }

    private void OnTriggerStay(Collider other)
    {
        var ai = other.GetComponent<AIBehaviour>();
        if (ai == null) return;
        CallAI(ai);
    }
}
