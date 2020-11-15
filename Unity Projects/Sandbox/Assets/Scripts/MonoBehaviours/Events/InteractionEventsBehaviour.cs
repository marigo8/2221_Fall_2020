using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class InteractionEventsBehaviour : EventsBehaviour
{
    
    public UnityEvent onInteractionEvent, onReadyEvent, offReadyEvent;
    
    private bool ready;

    private void Update()
    {
        if (!ready) return;
        if (!Input.GetButtonDown("Interact")) return;
        
        onInteractionEvent.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        ready = true;
        onReadyEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        ready = false;
        offReadyEvent.Invoke();
    }
}
