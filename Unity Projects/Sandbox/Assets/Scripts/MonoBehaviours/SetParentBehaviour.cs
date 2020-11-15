using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentBehaviour : MonoBehaviour
{
    public void SetParent(Transform parent)
    {
        transform.parent = parent;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
