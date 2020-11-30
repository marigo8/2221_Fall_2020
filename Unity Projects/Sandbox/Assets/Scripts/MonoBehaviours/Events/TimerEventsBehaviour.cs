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

    public void StartTimer(WaitData wait)
    {
        StartCoroutine(Timer(wait));
    }

    public IEnumerator Timer(float duration)
    {
        yield return new WaitForSeconds(duration);
        
        timerEvent.Invoke();
    }

    public IEnumerator Timer(WaitData wait)
    {
        yield return wait.Wait();
        
        timerEvent.Invoke();
    }
}
