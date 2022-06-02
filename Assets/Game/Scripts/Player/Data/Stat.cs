using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores the attribute value of a character supports buffs
/// </summary>
[CreateAssetMenu(fileName = "Stat", menuName = "Character/Stat")]
public class Stat : ScriptableObject
{
    //base value
    public float baseValue = 0;
    //after modification
    [ReadOnly]public float finalValue = 0;
    private List<Modifier> baseValueModifiers = new List<Modifier>();

    public virtual void Initialize()
    {
        finalValue = baseValue;
        baseValueModifiers.Clear();
    }

    public void AddBaseValueModifier(Modifier modifier)
    {
        baseValueModifiers.Add(modifier);
        CalculateBaseValue();
    }

    public void RemoveBaseValueModifier(Modifier modifier)
    {
        baseValueModifiers.Remove(modifier);
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
        for (int i = 0; i < baseValueModifiers.Count; i++)
        {
            if (!baseValueModifiers[i].isPersistent)
            {
                baseValueModifiers[i].remainingTime -= Time.deltaTime;
                if (baseValueModifiers[i].remainingTime <= 0)
                {
                    RemoveBaseValueModifier(baseValueModifiers[i]);
                }
            }
        }
    }
}
