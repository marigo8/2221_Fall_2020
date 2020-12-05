﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{
    public bool debugVelocity, autoFindTargets = true, slowBeforeAttack;

    public FloatData chaseSpeed, slowSpeed, attackSpeed, patrolSpeed, hitWallSpeed, tennisBallChaseSpeed, slowDistance, attackDistance;

    public Vector3List patrolPoints;

    public GameAction bossStunAction;

    public WaitData stunTime;

    public UnityEvent criticalWallHit;

    public int currentPatrolPoint;
    private bool hasPatrolPoints, canMove = true;
    public Vector3 parentForce;

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

    public void ClearPotentialTargets()
    {
        potentialTargets.Clear();
    }

    public bool GoToRandomPatrolPoint()
    {
        if (!hasPatrolPoints) return false;
        if (patrolPoints.vector3List.Count < 2) return false; // don't loop.
        var newPatrolPoint = Random.Range(0, patrolPoints.vector3List.Count - 1);
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

        if (stunTime != null)
        {
            stunTime.Initialize();
        }
    }

    private void Update()
    {
        if (parentForce.sqrMagnitude > 0)
        {
            agent.Move(parentForce * Time.deltaTime);
        }
        if (canMove)
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
        else
        {
            agent.destination = transform.position;
        }
    }

    public void OnWallHit(bool isCritical)
    {
        if (debugVelocity)
        {
            Debug.Log(agent.velocity.magnitude);
        }

        if (agent.velocity.magnitude < hitWallSpeed.value) return;

        bossStunAction.Raise();

        if (isCritical)
        {
            criticalWallHit.Invoke();
        }
        
        StartCoroutine(Stun());
    }

    private IEnumerator Stun()
    {
        canMove = false;
        yield return stunTime.Wait();
        canMove = true;
    }

private void Chase()
    {
        var highestPriority = potentialTargets[0];
        foreach (var potentialTarget in potentialTargets)
        {
            if (potentialTarget == null)
            {
                potentialTargets.Remove(potentialTarget);
                break;
            }
            
            if (potentialTarget.priority <= highestPriority.priority) continue;
            
            if (!agent.hasPath) continue;

            if (potentialTarget.isActiveAndEnabled == false || potentialTarget.priority <= 0)
            {
                Debug.Log(potentialTarget + " has allegedly been removed");
                potentialTargets.Remove(potentialTarget);
                break;
            }
            
            highestPriority = potentialTarget;
        }

        if (highestPriority == null)
        {
            Patrol();
            return;
        }

        if (highestPriority.priority >= 150)
        {
            agent.speed = tennisBallChaseSpeed.value;
        }
        else
        {
            if (slowBeforeAttack)
            {
                var remainingDistance = agent.remainingDistance;
                if (remainingDistance > slowDistance.value)
                {
                    agent.speed = chaseSpeed.value;
                }
                else if(remainingDistance > attackDistance.value)
                {
                    agent.speed = slowSpeed.value;
                }
                else
                {
                    agent.speed = chaseSpeed.value;
                }
            }
            else
            {
                agent.speed = chaseSpeed.value;
            }
        }

        agent.destination = highestPriority.transform.position;
    }

    private void Patrol()
    {
        agent.speed = patrolSpeed.value;
        agent.destination = patrolPoints.vector3List[currentPatrolPoint];
    }
}
