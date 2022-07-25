using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressbarController : MonoBehaviour
{
    [SerializeField] private FloatVariable stackAmount;
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    private void OnEnable() {
        fill.color = gradient.Evaluate(0f);
    }

    private void Update() 
    {
        slider.value = stackAmount.GetValue();
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
