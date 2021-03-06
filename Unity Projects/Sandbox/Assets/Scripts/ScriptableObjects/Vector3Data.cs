﻿using UnityEngine;

[CreateAssetMenu]
public class Vector3Data : ScriptableData
{
    public Vector3 value;

    public float x => value.x;
    public float y => value.y;
    public float z => value.z;

    public void SetValueFromVector3(Vector3 vector3)
    {
        value = vector3;
    }

    public void SetValueFromPosition(Transform transformObj)
    {
        value = transformObj.position;
    }

    public void SetValueFromRotation(Transform transformObj)
    {
        value = transformObj.eulerAngles;
    }

    public void SetPositionFromValue(Transform transformObj)
    {
        transformObj.position = value;
    }

    public void SetRotationFromValue(Transform transformObj)
    {
        transformObj.eulerAngles = value;
    }

    public void SetFromMousePosition()
    {
        if (Camera.main == null) return;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit);
        value = hit.point;
    }

    public override string GetString()
    {
        var text = label + ": " + value;
        return text;
    }
}