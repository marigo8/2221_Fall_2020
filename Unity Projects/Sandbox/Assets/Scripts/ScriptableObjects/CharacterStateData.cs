using UnityEngine;

[CreateAssetMenu]
public class CharacterStateData : ScriptableObject
{
    public enum States
    {
        Walking,
        Throwing,
        Stopped,
        KnockBack
    }

    public States currentState;

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

    private void OnEnable()
    {
        currentState = States.Walking;
    }
}
