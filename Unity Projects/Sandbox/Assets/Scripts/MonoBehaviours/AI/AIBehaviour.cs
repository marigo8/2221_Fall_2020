using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public AIBrainBase brain;
    public Vector3 target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (brain != null)
        {
            brain.OnNavigate(this);
        }
    }

    private void Update()
    {
        throw new NotImplementedException();
    }

    public void SwapBrain(AIBrainBase newBrain)
    {
        brain = newBrain;
        brain.OnNavigate(this);
    }

    private void OnDrawGizmosSelected()
    {
        if (agent == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(agent.destination,.25f);
    }
}
