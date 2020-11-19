using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Idle")]
public class AIIdle : AIBrainBase
{
    public override void OnUpdate(AIBehaviour ai)
    {
        base.OnUpdate(ai);
        ai.agent.destination = ai.transform.position;
    }
}
