using Project.Build.Commands;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Stores the attributes that have dynamic runtime values
/// </summary>
[CreateAssetMenu(fileName = "Survival Stat", menuName = "Character/Survival Stat")]
public class SurvivalStat : Stat
{
    public float minValue = 0;
    public float initialValue = 0;
    public float baseChangeRate = 0;
    [ReadOnly] public float actualChangeRate = 0;
    [ReadOnly] public float currentValue = 0;
    private List<Modifier> changeRateModifiers = new List<Modifier>();

    public override void Initialize()
    {
        base.Initialize();
        changeRateModifiers.Clear();
        currentValue = initialValue;
        actualChangeRate = baseChangeRate;
    }

    public void AddChangeRateModifier(Modifier modifier)
    {
        changeRateModifiers.Add(modifier);
        CalculateChangeRate();
    }

    public void RemoveChangeRateModifier(Modifier modifier)
    {
        changeRateModifiers.Remove(modifier);
        CalculateChangeRate();
    }

    private void CalculateChangeRate()
    {
        actualChangeRate = baseChangeRate;
        foreach (Modifier modifier in changeRateModifiers)
            actualChangeRate += modifier.magnitude;
    }

    public override void StatUpdate()
    {
        base.StatUpdate();
        foreach (Modifier modifier in changeRateModifiers)
        {
            if (!modifier.isPersistent)
            {
                modifier.remainingTime -= Time.deltaTime;
                if (modifier.remainingTime <= 0)
                {
                    RemoveChangeRateModifier(modifier);
                }
            }
        }
        currentValue += actualChangeRate * Time.deltaTime;
        currentValue = Mathf.Clamp(currentValue, minValue, finalValue); //actual Value is the modified attribute value which serves as the upperlimit
    }
}
