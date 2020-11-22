using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider))]
public class ConveyorBehaviour : MonoBehaviour
{
    public float speed;

    public void SetSpeed(float value)
    {
        speed = value;
    }

    private void OnTriggerStay(Collider other)
    {
        other.transform.position += transform.forward * speed * Time.fixedDeltaTime;
        var player = other.GetComponent<PlayerMoveBehaviour>();
        if (player != null)
        {
            player.parentForce = transform.forward * speed;
        }

        var enemy = other.GetComponent<NavMeshAgent>();
        if (enemy != null)
        {
            enemy.Move(transform.forward*speed*Time.fixedDeltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<PlayerMoveBehaviour>();
        if (player != null)
        {
            player.parentForce = Vector3.zero;
        }
    }
}
