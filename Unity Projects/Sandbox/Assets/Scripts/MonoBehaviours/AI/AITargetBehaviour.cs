using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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

        var distance = Vector3.Distance(transform.position, ai.transform.position);
        if (distance < minDistance)
        {
            arriveEvent.Invoke(ai);
        }
    }

    public void AIAttackTarget(AIBehaviour ai)
    {
        ai.StartAttack();
    }
}
