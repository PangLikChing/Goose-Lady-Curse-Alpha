using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SurvivalStat", menuName = "Character/SurvivalStat")]
public class SurvivalStat : ScriptableObject
{
    public float baseValue = 0;
    public float baseChangeRate = 0;
    public float minValue = 0; 
    public float maxValue = 0;
    public float currentValue = 0;
    public float currentChangeRate = 0;
    private List<float> maxValueModifiers = new List<float>();
    private List<float> changeRateModifiers = new List<float>();

    public void Initialize()
    {
        maxValue = baseValue;
    }

    public int AddMaxValueModifier(float modifier)
    {
        maxValueModifiers.Add(modifier);
        CalculateMaxValue();
        return maxValueModifiers.Count - 1;
    }

    public void RemoveMaxValueModifier(int modifierIndex)
    {
        CalculateMaxValue();
        maxValueModifiers.RemoveAt(modifierIndex);
    }

    public int AddChangeRateModifier(float modifier)
    {
        changeRateModifiers.Add(modifier);
        CalculateChangeRate();
        return changeRateModifiers.Count - 1;
    }

    public void RemoveChangeRateModifier(int modifierIndex)
    {
        changeRateModifiers.RemoveAt(modifierIndex);
        CalculateChangeRate();
    }

    private void CalculateMaxValue()
    {
        maxValue = baseValue;
        if (maxValueModifiers.Count != 0)
        {
            foreach (float modifier in maxValueModifiers)
                maxValue += modifier;
        }
    }

    private void CalculateChangeRate()
    {
        currentChangeRate = baseChangeRate;
        {
            foreach (float modifier in changeRateModifiers)
                currentChangeRate += modifier;
        }
    }

    public void StatUpdate()
    {
        currentValue += currentChangeRate*Time.deltaTime;
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
    }
}
