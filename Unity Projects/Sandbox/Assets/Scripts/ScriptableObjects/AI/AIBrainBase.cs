using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AIBrainBase : ScriptableObject
{
    public float baseSpeedModifier = 1f;
    
    public virtual void Activate(AIBehaviour ai)
    {
        ai.agent.speed = ai.baseSpeed * baseSpeedModifier;
    }

    public virtual void OnUpdate(AIBehaviour ai)
    {
        
    }
}
