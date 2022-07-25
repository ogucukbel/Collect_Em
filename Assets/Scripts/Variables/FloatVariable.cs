using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    public float floatVariable;
    public float maxFloatVariable;

    private void OnEnable() 
    {
        floatVariable = 0;
    }

    public void SetValue(float amount)
    {
        floatVariable = Mathf.Clamp(floatVariable, 0, maxFloatVariable);

    }

    public void Increase(float increaseAmount)
    {
        floatVariable = Mathf.Clamp(floatVariable + increaseAmount, 0, maxFloatVariable);
    }

    public void Decrease(float decreaseAmount)
    {
        floatVariable = Mathf.Clamp(floatVariable - decreaseAmount, 0, maxFloatVariable);
    }

    public float GetValue()
    {
        return floatVariable;
    }
}
