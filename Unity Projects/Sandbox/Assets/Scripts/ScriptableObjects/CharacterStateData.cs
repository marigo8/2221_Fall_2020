using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStateData : ScriptableObject
{
    public enum States
    {
        Walking,
        Throwing,
        Stopped
    }

    public States currentState;

    private void OnEnable()
    {
        currentState = States.Walking;
    }
}
