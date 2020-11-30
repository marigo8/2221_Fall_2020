using System;
using UnityEngine;
using UnityEngine.Events;

public class GameActionHandlerBehaviour : EventsBehaviour
{
    public GameAction gameAction;
    public float delay;

    public UnityEvent handlerEvent;

    private void Start()
    {
        gameAction.action += HandleAction;
    }

    private void OnDestroy()
    {
        gameAction.action -= HandleAction;
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