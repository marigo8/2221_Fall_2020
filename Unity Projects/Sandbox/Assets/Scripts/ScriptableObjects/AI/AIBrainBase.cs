using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AIBrainBase : ScriptableObject
{
    public float baseSpeedModifier = 1f;
    public float stoppingDistance;
    
    public virtual void Activate(AIBehaviour ai)
    {
        ai.agent.speed = ai.baseSpeed * baseSpeedModifier;
        ai.agent.stoppingDistance = stoppingDistance;
    }

    public virtual void OnUpdate(AIBehaviour ai)
    {
        
    }
}
