using System;
using System.Collections;
using UnityEngine;

public class PatrolPointBehaviour : MonoBehaviour
{
    public Vector3List patrolPointGroup;
    
    private static WaitForSeconds patrolDelay = new WaitForSeconds(1);
    private static WaitForFixedUpdate fixedWait = new WaitForFixedUpdate();

    private void Start()
    {
        patrolPointGroup.vector3List.Add(transform.position);
    }

    private void OnDisable()
    {
        patrolPointGroup.vector3List.Clear();
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        Debug.Log("Oh? You're Approaching me?");
        var ai = other.GetComponent<AIBehaviour>();
        if (ai == null) yield break;

        yield return patrolDelay;

        while (ai.GoToRandomPatrolPoint())
        {
            yield return fixedWait;
        }
    }
}
