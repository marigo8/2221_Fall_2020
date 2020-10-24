using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangVelocity : MonoBehaviour
{
    public bool canShoot = true;
    public Rigidbody rBody;
    public WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    public Vector3 initalVelocity; // <---

    public IEnumerator Start()
    {
        rBody.velocity = initalVelocity; // <---
        var originalVelocity = initalVelocity;
        while (canShoot)
        {
            rBody.velocity = Vector3.Lerp(rBody.velocity, -originalVelocity, 1f);
            yield return wffu;
            Debug.Log("ack");
        }
    }
}