using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCameraHeightBehaviour : MonoBehaviour
{
    public float height;

    private void LateUpdate()
    {
        var position = transform.position;
        position.y = height;
        transform.position = position;
    }
}
