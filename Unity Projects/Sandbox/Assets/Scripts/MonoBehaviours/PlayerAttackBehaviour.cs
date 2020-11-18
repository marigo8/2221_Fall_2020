using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttackBehaviour : MonoBehaviour
{
    public CharacterStateData playerState;
    public float attackLength;

    public UnityEvent attackEvent, endAttackEvent;

    private WaitForSeconds attackWait;

    private void Start()
    {
        attackWait = new WaitForSeconds(attackLength);
    }

    private void Update()
    {
        if (!Input.GetButtonDown("Fire1")) return;
        if (playerState.currentState != CharacterStateData.States.Walking) return;
        
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        playerState.currentState = CharacterStateData.States.Attacking;
        attackEvent.Invoke();
        
        yield return attackWait;

        endAttackEvent.Invoke();
        playerState.currentState = CharacterStateData.States.Walking;
    }
}
