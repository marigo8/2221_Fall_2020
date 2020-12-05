using UnityEngine;

public class EventsBehaviour : MonoBehaviour
{
    public void DestroyObject(GameObject other)
    {
        Destroy(other);
    }
    
    public void DestroyObject(Collider other)
    {
        Destroy(other.gameObject);
    }
}