using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class InteractionEventsBehaviour : EventsBehaviour
{
    public bool holdButtonDown;
    public UnityEvent onInteractionEvent, onReadyEvent, offReadyEvent;
    
    private bool ready;

    private void Update()
    {
        if (!ready) return;
        if (holdButtonDown)
        {
            if (Input.GetButton("Interact"))
            {
                onInteractionEvent.Invoke();
            }
        }
        else
        {
            if (Input.GetButtonDown("Interact"))
            {
                onInteractionEvent.Invoke();
            }
        }
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
