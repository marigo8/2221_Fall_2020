using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class TimerObject : ScriptableData
{
    public float duration;
    public float currentTime;

    public UnityEvent timerEvent;
    
    private bool isRunning;
    private WaitForFixedUpdate fixedWait;

    private void OnEnable()
    {
        fixedWait = new WaitForFixedUpdate();
        currentTime = 0;
    }

    public override string GetString()
    {
        var text = label + ": " + currentTime.ToString("F1");

        return text;
    }

    public override float GetFraction()
    {
        return currentTime / duration;
    }

    public IEnumerator Countdown()
    {
        currentTime = duration;

        while (currentTime > 0)
        {
            yield return fixedWait;
            currentTime -= Time.fixedDeltaTime;
        }
        timerEvent.Invoke();
    }
}
