using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileBehaviour : InstanceBehaviour
{
    public Vector3 force;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(force);
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
