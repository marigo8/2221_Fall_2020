using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIFollowTargetBehaviour : MonoBehaviour
{
    public Transform target, player;
    public bool followTarget;
    
    private NavMeshAgent agent;

    public void SetTargetFromCollider(Collider other)
    {
        target = other.transform;
        followTarget = true;
    }

    public void StopFollowing()
    {
        followTarget = false;
        agent.destination = transform.position;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!followTarget) return;

        if (target == null)
        {
            target = player;
        }
        
        agent.destination = target.position;
    }
}
