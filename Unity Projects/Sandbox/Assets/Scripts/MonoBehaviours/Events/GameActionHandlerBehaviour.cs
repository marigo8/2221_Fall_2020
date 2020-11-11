using UnityEngine;
using UnityEngine.Events;

public class GameActionHandlerBehaviour : MonoBehaviour
{
    public GameAction gameAction;
    public float delay;

    public UnityEvent handlerEvent;

    private void Start()
    {
        gameAction.action += HandleAction;
    }

    private void HandleAction()
    {
        Invoke(nameof(OnHandleAction), delay);
    }

    private void OnHandleAction()
    {
        handlerEvent.Invoke();
    }
}