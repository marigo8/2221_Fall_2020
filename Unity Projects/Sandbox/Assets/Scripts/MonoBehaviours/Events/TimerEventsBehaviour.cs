using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerEventsBehaviour : EventsBehaviour
{
    public UnityEvent timerEvent;

    public void StartTimer(FloatData duration)
    {
        StartTimer(duration.value);
    }

    public void StartTimer(float duration)
    {
        StartCoroutine(Timer(duration));
    }

    public IEnumerator Timer(float duration)
    {
        yield return new WaitForSeconds(duration);
        
        timerEvent.Invoke();
    }
}
