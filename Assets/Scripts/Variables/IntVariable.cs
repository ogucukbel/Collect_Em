using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class IntVariable : ScriptableObject
{
    public int intVariable;
    public int maxIntVariable;



    public void SetValue(float amount)
    {
        intVariable = Mathf.Clamp(intVariable, 0, maxIntVariable);

    }

    public void Increase(int increaseAmount)
    {
        intVariable = Mathf.Clamp(intVariable + increaseAmount, 0, maxIntVariable);
    }
    public void Decrease(int decreaseAmount)
    {
        intVariable = Mathf.Clamp(intVariable - decreaseAmount, 0, maxIntVariable);
    }

    public int GetValue()
    {
        return intVariable;
    }
}
