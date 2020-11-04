using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntervalEventsBehaviour : MonoBehaviour
{
    public float intervalTime;
    
    public UnityEvent eventA, eventB;

    private WaitForSeconds intervalWait;

    private void Start()
    {
        intervalWait = new WaitForSeconds(intervalTime);
        StartCoroutine(Interval());
    }

    private IEnumerator Interval()
    {
        yield return intervalWait;
        
        eventA.Invoke();
        
        yield return intervalWait;
        
        eventB.Invoke();
        StartCoroutine(Interval());
    }
}
