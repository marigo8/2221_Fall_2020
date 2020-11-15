using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PickUpBehaviour : EventsBehaviour
{
    public ScriptableData data;
    public bool checkIfMaxed;

    public UnityEvent pickUpEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (checkIfMaxed)
        {
            if (!data.CanBeAltered()) return;
        }

        pickUpEvent.Invoke();
    }
}
