using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorBehaviour : MonoBehaviour
{
    public TimerObject timer;
    
    private Animator anim;
    private Coroutine timerCoroutine;

    private void Start()
    {
        // Get Components
        anim = GetComponent<Animator>();
        
        // Set Up Timer Event
        timer.timerEvent.AddListener(Close);
    }

    public void Open()
    {
        // Countdown should reset once the door is opened again.
        StopCountDown();
        
        // Animate door opening.
        anim.SetBool("Open",true);
    }

    public void StartCountDown()
    {
        // Stop Countdown if it is already running.
        StopCountDown();
        
        // Start Countdown
        timerCoroutine = StartCoroutine(timer.Countdown());
    }

    public void StopCountDown()
    {
        // Reset time
        timer.currentTime = timer.duration;
        
        // Stop
        if (timerCoroutine == null) return;
        StopCoroutine(timerCoroutine);
    }
    public void Close()
    {
        // Animate Door Closing.
        anim.SetBool("Open",false);
    }
}
