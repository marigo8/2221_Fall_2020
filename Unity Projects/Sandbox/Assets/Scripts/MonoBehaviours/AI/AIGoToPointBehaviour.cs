using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIGoToPointBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;

    public void SetTargetPoint(Transform target)
    {
        agent.SetDestination(target.position);
    }
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(transform.position);
    }
}
