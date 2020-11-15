using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoEventsBehaviour : EventsBehaviour
{
    public UnityEvent startEvent, updateEvent, enableEvent, destroyEvent;

    private void Start()
    {
        startEvent.Invoke();
    }

    private void Update()
    {
        updateEvent.Invoke();
    }

    private void OnEnable()
    {
        enableEvent.Invoke();
    }

    private void OnDestroy()
    {
        destroyEvent.Invoke();
    }
}
