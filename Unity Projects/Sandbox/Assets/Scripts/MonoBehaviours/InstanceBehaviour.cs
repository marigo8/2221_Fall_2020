using UnityEngine;

public class InstanceBehaviour : MonoBehaviour
{
    public void CreateInstance(Transform transformObj)
    {
        Instantiate(gameObject, transformObj.position, transformObj.rotation);
    }
}