using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores the attribute value of a character
/// </summary>
[CreateAssetMenu(fileName = "Stat", menuName = "Character/Stat")]
public class Stat : ScriptableObject
{
    //base value
    public float baseValue = 0;
    //after modification
    [ReadOnly]public float finalValue = 0;
    private List<Modifier> baseValueModifiers = new List<Modifier>();
    private List<float> baseValueModifierRemainingTimes = new List<float>();
    public virtual void Initialize()
    {
        finalValue = baseValue;
        baseValueModifiers.Clear();
    }

    public int AddBaseValueModifier(Modifier modifier)
    {
        baseValueModifiers.Add(modifier);
        baseValueModifierRemainingTimes.Add(modifier.duration);
        CalculateBaseValue();
        return baseValueModifiers.Count - 1;
    }

    public void RemoveBaseValueModifier(int modifierIndex)
    {
        baseValueModifiers.RemoveAt(modifierIndex);
        baseValueModifierRemainingTimes.RemoveAt(modifierIndex);
        CalculateBaseValue();
    }

    public void CalculateBaseValue()
    {
        finalValue = baseValue;
        foreach (Modifier modifier in baseValueModifiers)
            finalValue += modifier.magnitude;
    }

    public virtual void StatUpdate()
    {
        for (int i = baseValueModifiers.Count-1; i >=0; i-- )
        {
            if (!baseValueModifiers[i].isPersistent)
            {
                baseValueModifierRemainingTimes[i] -= Time.deltaTime;
                if (baseValueModifierRemainingTimes[i] <= 0)
                {
                    RemoveBaseValueModifier(i);
                }
            }
        }
    }
}
