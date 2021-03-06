﻿using UnityEngine;

[CreateAssetMenu]
public class CharacterStateData : ScriptableObject
{
    public enum States
    {
        Walking,
        Throwing,
        Stopped,
        KnockBack,
        Dialogue
    }

    public States currentState;

    public Transform lookAtTarget;

    public void SetWalking()
    {
        currentState = States.Walking;
    }

    public void SetThrowing()
    {
        currentState = States.Throwing;
    }

    public void SetStopped()
    {
        currentState = States.Stopped;
    }

    public void SetDialogue()
    {
        currentState = States.Dialogue;
    }

    public void SetLookAtTarget(Transform target)
    {
        lookAtTarget = target;
    }

    private void OnEnable()
    {
        currentState = States.Walking;
    }
}
