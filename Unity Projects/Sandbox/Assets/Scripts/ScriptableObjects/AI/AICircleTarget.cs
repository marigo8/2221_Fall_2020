using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Circle")]
public class AICircleTarget : AIBrainBase
{
    public override void Activate(AIBehaviour ai)
    {
        base.Activate(ai);
        if (Random.value > .5f)
        {
            ai.circleDirection = 1f;
        }
        else
        {
            ai.circleDirection = -1f;
        }
    }

    public override void OnUpdate(AIBehaviour ai)
    {
        if (ai.target == null) return;
        var targetDirection = (ai.target.position - ai.transform.position).normalized;

        var tangentDirection = Quaternion.AngleAxis(90 * ai.circleDirection, Vector3.up) * targetDirection;
        
        ai.agent.destination = ai.transform.position + tangentDirection;
    }
}
