using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Go To Target")]
public class AIGoToTarget : AIBrainBase
{
    public override void OnNavigate(AIBehaviour ai)
    {
        base.OnNavigate(ai);
        ai.agent.destination = ai.target;
    }

    public override void OnDestination(AIBehaviour ai)
    {
        base.OnDestination(ai);
        Debug.Log("Hip Hip Hooray");
    }
}
