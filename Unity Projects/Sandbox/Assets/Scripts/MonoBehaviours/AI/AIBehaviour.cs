using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{
    public AIBrainBase brain, attackBrain, damagedBrain;
    public Transform target;
    public List<Transform> patrolPoints;

    public NavMeshAgent agent;
    public float baseSpeed, circleDirection, attackWaitMin, attackWaitMax;

    public UnityEvent attackEvent, endAttackEvent;

    private Coroutine attackWaitCoroutine;

    private readonly WaitForSeconds attackTimeOut = new WaitForSeconds(1);

    public void SetTarget(Collider newTarget)
    {
        target = newTarget.transform;
    }

    public void StartWaitToAttack()
    {
        if (attackWaitCoroutine != null) return;

        attackWaitCoroutine = StartCoroutine(WaitToAttack());
    }

    public void EndWaitToAttack()
    {
        if (attackWaitCoroutine == null) return;
        StopCoroutine(attackWaitCoroutine);
        attackWaitCoroutine = null;
    }

    public void EndAttack()
    {
        endAttackEvent.Invoke();
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = baseSpeed;
        
        if (brain != null)
        {
            brain.Activate(this);
        }
    }

    private void Update()
    {
        brain.OnUpdate(this);
    }

    public void SwapBrain(AIBrainBase newBrain)
    {
        brain = newBrain;
        brain.Activate(this);
    }

    private void OnDrawGizmosSelected()
    {
        if (agent == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(agent.destination,.25f);
    }

    private IEnumerator Attack()
    {
        attackEvent.Invoke();
        SwapBrain(attackBrain);
        yield return attackTimeOut;

        EndAttack();
    }

    private IEnumerator WaitToAttack()
    {
        var attackWait = Random.Range(attackWaitMin, attackWaitMax);
        yield return new WaitForSeconds(attackWait);

        attackWaitCoroutine = null;
        StartCoroutine(Attack());
    }
}
