using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class InteractionEventsBehaviour : MonoBehaviour
{
    public bool toggle;
    
    public UnityEvent onInteractionEvent, offInteractionEvent, onReadyEvent, offReadyEvent;

    private Collider col;
    private bool ready, toggleOn = true;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    private void Update()
    {
        if (!ready) return;

        if (Input.GetButtonDown("Interact"))
        {
            if (toggleOn)
            {
                onInteractionEvent.Invoke();
            }
            else
            {
                offInteractionEvent.Invoke();
            }

            if (toggle)
            {
                toggleOn = !toggleOn;
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
