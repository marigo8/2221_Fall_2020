using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Slider))]
public class HudSliderBehaviour : MonoBehaviour
{
    public FloatData health, maxHealth;
    
    private Slider healthSlider;
    private RectTransform sliderTransform;

    private void Start()
    {
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = maxHealth.value;
        sliderTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        healthSlider.value = health.value;
        sliderTransform.sizeDelta = new Vector2(maxHealth.value, sliderTransform.sizeDelta.y);
    }
}
