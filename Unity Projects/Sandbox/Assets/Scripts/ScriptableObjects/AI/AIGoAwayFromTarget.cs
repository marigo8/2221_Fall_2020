using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Go Away From Target")]
public class AIGoAwayFromTarget : AIBrainBase
{
    public override void OnUpdate(AIBehaviour ai)
    {
        if (ai.target == null) return;
        var direction = (ai.transform.position - ai.target.position).normalized;
        
        ai.agent.destination = ai.transform.position + direction;
    }
}
