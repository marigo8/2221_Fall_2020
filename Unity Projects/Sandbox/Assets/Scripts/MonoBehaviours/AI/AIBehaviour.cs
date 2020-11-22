﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{
    public FloatData chaseSpeed, patrolSpeed;
    
    public Vector3List patrolPoints;

    private int currentPatrolPoint;
    private bool attackMode, hasPatrolPoints;
    
    private List<AITargetBehaviour> potentialTargets = new List<AITargetBehaviour>();

    private NavMeshAgent agent;

    public void AddPotentialTarget(AITargetBehaviour target)
    {
        if (potentialTargets.Contains(target)) return;
        potentialTargets.Add(target);
    }

    public void RemovePotentialTarget(AITargetBehaviour target)
    {
        if (!potentialTargets.Contains(target)) return;
        potentialTargets.Remove(target);
    }

    public bool GoToRandomPatrolPoint()
    {
        if (!hasPatrolPoints) return false;
        Debug.Log("GoToRandomPoint");
        if (patrolPoints.vector3List.Count < 2) return false; // don't loop.
        var newPatrolPoint = Random.Range(0, patrolPoints.vector3List.Count-1);
        if (currentPatrolPoint != newPatrolPoint)
        {
            currentPatrolPoint = newPatrolPoint;
            return false; // stop loop.
        }
        else
        {
            return true; // continue loop.
        }
    }

    private void Start()
    {
        hasPatrolPoints = patrolPoints != null;
        agent = GetComponent<NavMeshAgent>();
        GoToRandomPatrolPoint();
    }

    private void FixedUpdate()
    {
        if (potentialTargets.Count <= 0)
        {
            if (hasPatrolPoints)
            {
                Patrol();
            }
            else
            {
                agent.destination = transform.position;
            }
        }
        else
        {
            Chase();
        }
    }

    private void Chase()
    {
        agent.speed = chaseSpeed.value;
        var highestPriority = potentialTargets[0];
        foreach (var potentialTarget in potentialTargets)
        {
            if (potentialTarget.priority <= highestPriority.priority) continue;
            
            if (!agent.hasPath) continue;

            if (potentialTarget.isActiveAndEnabled == false)
            {
                potentialTargets.Remove(potentialTarget);
                continue;
            }
            
            highestPriority = potentialTarget;
        }

        if (highestPriority == null)
        {
            Patrol();
            return;
        }
        agent.destination = highestPriority.transform.position;
    }

    private void Patrol()
    {
        agent.speed = patrolSpeed.value;
        agent.destination = patrolPoints.vector3List[currentPatrolPoint];
    }
}
