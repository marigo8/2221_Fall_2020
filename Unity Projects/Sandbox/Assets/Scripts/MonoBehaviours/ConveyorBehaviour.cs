using System;
using UnityEngine;

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
        if (!other.CompareTag("Player")) return;
        other.GetComponent<PlayerMoveBehaviour>().parentForce = transform.forward * speed;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        other.GetComponent<PlayerMoveBehaviour>().parentForce = Vector3.zero;
    }
}
