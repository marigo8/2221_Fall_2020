using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIGoToPointBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;

    public void GoToPoint(Vector3 destination)
    {
        agent.destination = destination;
    }

    public void GoToPoint(Transform obj)
    {
        GoToPoint(obj.position);
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
