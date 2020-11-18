using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Go To Target")]
public class AIGoToTarget : AIBrainBase
{

    public override void OnUpdate(AIBehaviour ai)
    {
        if (ai.target == null) return;
        base.OnUpdate(ai);
        ai.agent.destination = ai.target.position;
    }
}
