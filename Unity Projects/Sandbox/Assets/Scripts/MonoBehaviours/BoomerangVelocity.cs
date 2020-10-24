using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoomerangVelocity : MonoBehaviour
{
    public float airTime;
    public bool inTheAir = true;
    public Vector3 initialVelocity;
    
    private Rigidbody rBody;
    private WaitForFixedUpdate wffu = new WaitForFixedUpdate();

    public IEnumerator Start()
    {
        rBody = GetComponent<Rigidbody>();
        
        rBody.velocity = initialVelocity;
        var originalVelocity = initialVelocity;
        while (inTheAir)
        {
            rBody.velocity = Vector3.Lerp(rBody.velocity, -originalVelocity, airTime*Time.deltaTime);
            yield return wffu;
            Debug.Log("ack");
        }
    }
}