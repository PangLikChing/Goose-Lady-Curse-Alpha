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
    public List<float> maxValueModifiers = new List<float>();
    public List<float> changeRateModifiers = new List<float>();

    public void Initialize()
    {
        maxValue = baseValue;
        currentValue = baseValue;
    }

    public int AddBaseValueModifier(float modifier)
    {
        maxValueModifiers.Add(modifier);
        return maxValueModifiers.Count - 1;
    }

    public void RemoveBaseValueModifier(int modifierIndex)
    {
        maxValueModifiers.RemoveAt(modifierIndex);
    }

    public int AddChangeRateModifier(float modifier)
    {
        changeRateModifiers.Add(modifier);
        return changeRateModifiers.Count - 1;
    }

    public void RemoveChangeRateModifier(int modifierIndex)
    {
        changeRateModifiers.RemoveAt(modifierIndex);
    }

    public void StatUpdate()
    {
        maxValue = baseValue;
        if (maxValueModifiers.Count != 0)
        {
            foreach (float modifier in maxValueModifiers)
                maxValue += modifier;
        }
        currentChangeRate = baseChangeRate;
        {
            foreach (float modifier in changeRateModifiers)
                currentChangeRate += modifier;
        }
        currentValue += currentChangeRate;
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
    }
}
