using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{
    public FloatData chaseSpeed, patrolSpeed, attackDelay;
    
    public Vector3List patrolPoints;

    public UnityEvent attackEvent, attackEndEvent;

    private int currentPatrolPoint;
    private bool attackMode;
    
    private List<AITargetBehaviour> potentialTargets = new List<AITargetBehaviour>();

    private NavMeshAgent agent;

    public void AddPotentialTarget(AITargetBehaviour target)
    {
        if (potentialTargets.Contains(target)) return;
        potentialTargets.Add(target);
    }

    public bool GoToRandomPatrolPoint()
    {
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
        agent = GetComponent<NavMeshAgent>();
        GoToRandomPatrolPoint();
    }

    private void FixedUpdate()
    {
        if (potentialTargets.Count <= 0)
        {
            Patrol();
        }
        else
        {
            Chase();
        }

        potentialTargets.Clear();
    }

    private void Chase()
    {
        agent.speed = chaseSpeed.value;
        var highestPriority = potentialTargets[0];
        foreach (var potentialTarget in potentialTargets)
        {
            if (potentialTarget.priority > highestPriority.priority)
            {
                highestPriority = potentialTarget;
            }
        }

        if (highestPriority == null) return;
        agent.destination = highestPriority.transform.position;
    }

    private void Patrol()
    {
        agent.speed = patrolSpeed.value;
        agent.destination = patrolPoints.vector3List[currentPatrolPoint];
    }

    public void StartAttack()
    {
        if (attackMode) return;
        attackMode = true;

        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        var delay = Random.Range(attackDelay.value, attackDelay.maxValue);
        
        yield return new WaitForSeconds(delay);
        
        attackEvent.Invoke();
        
        yield return new WaitForSeconds(1f);
        
        attackEndEvent.Invoke();
        
        attackMode = false;
    }
}
