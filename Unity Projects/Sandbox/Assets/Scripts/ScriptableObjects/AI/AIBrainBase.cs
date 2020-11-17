using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AIBrainBase : ScriptableObject
{
    public virtual void OnNavigate(AIBehaviour ai)
    {
        
    }

    public virtual void OnDestination(AIBehaviour ai)
    {
        
    }
}
