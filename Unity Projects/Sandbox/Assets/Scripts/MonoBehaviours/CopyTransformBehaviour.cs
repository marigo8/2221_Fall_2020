using System;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class CopyTransformBehaviour : MonoBehaviour
{
    public Transform target;
    public bool copyPosition, copyRotation, copyScale;

    private bool hasTarget;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        hasTarget = true;
    }

    private void Start()
    {
        hasTarget = target != null;
    }

    private void Update()
    {
        if (!hasTarget) return;
        
        if (copyPosition)
        {
            transform.position = target.position;
        }

        if (copyRotation)
        {
            transform.rotation = target.rotation;
        }

        if (copyScale)
        {
            transform.localScale = target.localScale;
        }
    }
}
