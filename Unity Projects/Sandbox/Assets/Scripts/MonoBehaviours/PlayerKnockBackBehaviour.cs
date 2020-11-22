using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockBackBehaviour : MonoBehaviour
{
    public FloatData knockBackForce;

    public void KnockbackPlayer(Collider other)
    {
        var player = other.GetComponent<PlayerMoveBehaviour>();
        if (player == null) return;
        
        var knockBackVector = player.transform.position - transform.position;
        
        player.AddForce(knockBackVector * knockBackForce.value);
    }
}
