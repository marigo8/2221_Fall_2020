using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class LerpBehaviour : MonoBehaviour
{
    public Transform pointATransform, pointBTransform;
    [Range(0,1)]
    public float step;
    public UnityEvent pointAEvent, pointBEvent;

    private bool eventInvoked;
    private Animator anim;
    private static readonly int GoToBParam = Animator.StringToHash("GoToB");

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void MoveToPoint(bool goToB)
    {
        anim.SetBool(GoToBParam, goToB);
    }

    public void MoveToggle()
    {
        anim.SetBool(GoToBParam, !anim.GetBool(GoToBParam));
    }

    // v Move these two methods to a different script v
    public void SetColliderParent(Collider other)
    {
        other.transform.parent = transform;
    }

    public void ClearColliderParent(Collider other)
    {
        other.transform.parent = null;
    }

    private void FixedUpdate()
    {
        Mathf.Clamp(step, 0, 1);
        transform.position = Vector3.Lerp(pointATransform.position, pointBTransform.position, step);
        if (!eventInvoked)
        {
            if (step <= 0)
            {
                pointAEvent.Invoke();
                eventInvoked = true;
            }
            else if (step >= 1)
            {
                pointBEvent.Invoke();
                eventInvoked = true;
            }
        }
        else if (0 < step && step < 1)
        {
            eventInvoked = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (pointBTransform == null) return;
        Gizmos.DrawWireCube(pointBTransform.position, transform.localScale);
        Gizmos.DrawLine(transform.position, pointBTransform.position);
    }
}