using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIHealthBehaviour : MonoBehaviour
{
    public FloatData playerStamina;
    public int health, weakAttack, strongAttack;

    public UnityEvent onZero;

    public void TakeDamage()
    {
        if (playerStamina.value > 0)
        {
            health -= strongAttack;
        }
        else
        {
            health -= weakAttack;
        }
        if (health <= 0)
        {
            onZero.Invoke();
        }
    }
}
