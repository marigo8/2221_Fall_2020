using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsBehaviour : MonoBehaviour
{
    public void DestroyObject(GameObject other)
    {
        DestroyObject(other);
    }
    
    public void DestroyObject(Collider other)
    {
        Destroy(other.gameObject);
    }
}
