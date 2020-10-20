using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ScriptableDataImageBehaviour : MonoBehaviour
{
    public ScriptableData data;
    private Image imageObj;

    private void Start()
    {
        imageObj = GetComponent<Image>();
    }

    private void Update()
    {
        imageObj.fillAmount = data.GetFraction();
    }
}