﻿using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[RequireComponent(typeof(Collider))]
public class TriggerEventsBehaviour : EventsBehaviour
{
    public string filterTag;
    
    public UnityEvent<Collider> triggerEnterEvent;
    public UnityEvent<Collider> triggerStayEvent;
    public UnityEvent<Collider> triggerExitEvent;

    private void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (filterTag != "") // If there is no tag, just invoke the event.
        {
            if (!other.CompareTag(filterTag)) return; // if there is a tag but it doesn't match, don't invoke the event.
        }
        triggerEnterEvent.Invoke(other);
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (filterTag != "")
        {
            if (!other.CompareTag(filterTag)) return;
        }
        triggerStayEvent.Invoke(other);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (filterTag != "")
        {
            if (!other.CompareTag(filterTag)) return;
        }
        triggerExitEvent.Invoke(other);
    }
}
