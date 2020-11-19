using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "AI/Patrol")]
public class AIPatrol : AIBrainBase
{
    private readonly WaitForFixedUpdate fixedWait = new WaitForFixedUpdate();
    private readonly WaitForSeconds patrolDelayWait = new WaitForSeconds(2);
    public override void Activate(AIBehaviour ai)
    {
        base.Activate(ai);
        ai.StartCoroutine(Patrol(ai));
    }
    
    private IEnumerator Patrol(AIBehaviour ai)
    {
        var index = Random.Range(0, ai.patrolPoints.Count);
        ai.agent.destination = ai.patrolPoints[index].position;
    
        while (!ai.agent.pathPending && ai.agent.remainingDistance > 0.5f)
        {
            yield return fixedWait;
        }
        
        yield return patrolDelayWait;
        if (ai.brain != this) yield break;
    
        ai.StartCoroutine(Patrol(ai));
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
}
