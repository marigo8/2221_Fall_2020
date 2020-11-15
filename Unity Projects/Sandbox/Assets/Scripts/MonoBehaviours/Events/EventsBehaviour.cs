using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsBehaviour : MonoBehaviour
{
    public void DestroyCollider(Collider other)
    {
        Destroy(other.gameObject);
    }
}
