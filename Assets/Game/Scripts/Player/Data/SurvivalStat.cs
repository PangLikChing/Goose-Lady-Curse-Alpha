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
    //[ReadOnly]
    public float currentValue = 0;
    [SerializeField,ReadOnly]
    private List<Modifier> changeRateModifiers = new List<Modifier>();
    [SerializeField, ReadOnly]
    private List<float> changeRateModifierRemainingTimes = new List<float>();

    public override void Initialize()
    {
        base.Initialize();
        changeRateModifiers.Clear();
        changeRateModifierRemainingTimes.Clear();
        currentValue = initialValue;
        actualChangeRate = baseChangeRate;
    }

    public int AddChangeRateModifier(Modifier modifier)
    {
        changeRateModifiers.Add(modifier);
        changeRateModifierRemainingTimes.Add(modifier.duration);
        CalculateChangeRate();
        return changeRateModifiers.Count - 1;
    }

    public void RemoveChangeRateModifier(Modifier modifier)
    {
        int index = changeRateModifiers.IndexOf(modifier);
        changeRateModifiers.RemoveAt(index);
        changeRateModifierRemainingTimes.RemoveAt(index);
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
        for (int i = changeRateModifiers.Count-1; i >= 0; i--)
        {
            if (!changeRateModifiers[i].isPersistent)
            {
                changeRateModifierRemainingTimes[i] -= Time.deltaTime;
                if (changeRateModifierRemainingTimes[i] <= 0)
                {
                    RemoveChangeRateModifier(changeRateModifiers[i]);
                }
            }
        }

        currentValue += actualChangeRate * Time.deltaTime;
        currentValue = Mathf.Clamp(currentValue, minValue, finalValue); //final Value is the modified attribute value which serves as the upperlimit
    }
}
