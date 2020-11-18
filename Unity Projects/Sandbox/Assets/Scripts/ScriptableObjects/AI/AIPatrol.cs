using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "AI/Patrol")]
public class AIPatrol : AIBrainBase
{
    public override void Activate(AIBehaviour ai)
    {
        base.Activate(ai);
    }

    public override void OnUpdate(AIBehaviour ai)
    {
        base.OnUpdate(ai);
    }

    // public Vector3Data patrolOrigin;
    // public float patrolRadius;
    // public float patrolDelay;
    //
    // private WaitForFixedUpdate fixedWait;
    // private WaitForSeconds patrolDelayWait;
    //
    // public override void OnNavigate(AIBehaviour ai)
    // {
    //     base.OnNavigate(ai);
    //
    //     if (patrolDelayWait == null)
    //     {
    //         patrolDelayWait = new WaitForSeconds(patrolDelay);
    //     }
    //     
    //     if (patrolOrigin == null)
    //     {
    //         Debug.LogError("No patrol origin set!");
    //         return;
    //     }
    //     ai.StartCoroutine(Patrol(ai));
    // }
    //
    // private IEnumerator Patrol(AIBehaviour ai)
    // {
    //     ai.agent.destination = patrolOrigin.value + Random.insideUnitSphere * patrolRadius;
    //
    //     var timeElapsed = 0f;
    //     while (!ai.agent.pathPending && ai.agent.remainingDistance > 0.5f)
    //     {
    //         yield return fixedWait;
    //         timeElapsed += Time.fixedDeltaTime;
    //     }
    //     Debug.Log(timeElapsed);
    //     
    //     yield return patrolDelayWait;
    //     if (ai.brain != this) yield break;
    //
    //     ai.StartCoroutine(Patrol(ai));
    // }
}
