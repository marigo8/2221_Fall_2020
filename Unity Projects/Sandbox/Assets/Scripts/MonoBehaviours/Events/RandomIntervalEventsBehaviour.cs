using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class RandomIntervalEventsBehaviour : EventsBehaviour
{
    public float minTime, maxTime;
    public bool doInterval = true, intervalOnStart;

    public UnityEvent intervalEvent;

    private void Start()
    {
        if (!intervalOnStart) return;

        StartCoroutine(Interval());
    }

    public void StartInterval()
    {
        StartCoroutine(Interval());
    }
    private IEnumerator Interval()
    {
        if (!doInterval) yield break;
        intervalEvent.Invoke();
        var waitTime = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(Interval());
    }
}
