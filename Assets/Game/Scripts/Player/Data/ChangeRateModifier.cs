using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Change Rate Modifier", menuName = "Character/Change Rate Modifier")]
public class ChangeRateModifier : Modifier
{
    public SurvivalStat targetStat;

    public override void Apply()
    {
        targetStat.AddChangeRateModifier(this);
    }

    public override void Remove()
    {
        targetStat.RemoveChangeRateModifier(this);
    }
}
