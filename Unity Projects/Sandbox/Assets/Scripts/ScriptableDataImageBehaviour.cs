using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ScriptableDataImageBehaviour : MonoBehaviour
{
    public ScriptableData data;
    public Gradient gradient, backgroundGradient;
    public Image background;
    
    private Image imageObj;
    private bool isBackgroundNull;

    private void Start()
    {
        isBackgroundNull = background == null;
        imageObj = GetComponent<Image>();
    }

    private void Update()
    {
        var fraction = data.GetFraction();
        
        imageObj.fillAmount = fraction;
        imageObj.color = gradient.Evaluate(fraction);

        if (isBackgroundNull) return;
        background.color = backgroundGradient.Evaluate(fraction);
    }
}