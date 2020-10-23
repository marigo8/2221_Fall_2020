using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MeshMaterialBehaviour : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Color originalColor;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
    }

    public void FlashRed()
    {
        StartCoroutine(FlashRedCoroutine());
    }

    private IEnumerator FlashRedCoroutine()
    {
        var red = Color.Lerp(originalColor, Color.red, .75f);

        meshRenderer.material.color = red;
        
        yield return new WaitForSeconds(.5f);

        meshRenderer.material.color = originalColor;
    }
}
