using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileBehaviour : InstanceBehaviour
{
    // public Vector3 force;
    // public float lifeTime;
    //
    // private Rigidbody rb;
    //
    // private void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    //     rb.AddRelativeForce(force);
    // }
    //
    // public void DestroyProjectile()
    // {
    //     Destroy(gameObject);
    // }
    //
    // public void DistractEnemy(Collider other)
    // {
    //     var enemy = other.GetComponent<AIFollowTargetBehaviour>();
    //     if (enemy == null) return;
    //
    //     enemy.target = transform;
    // }
    //
    // public void Decay()
    // {
    //     lifeTime -= Time.deltaTime;
    //     if (lifeTime <= 0)
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
