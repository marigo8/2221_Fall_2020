using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class HudScaleBehaviour : MonoBehaviour
{
    private RectTransform rect;
    private Vector2 originalSize;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        originalSize = rect.sizeDelta;
    }

    public void Resize(int scaleFactor = 1)
    {
        rect.sizeDelta = originalSize * scaleFactor;
    }
}
