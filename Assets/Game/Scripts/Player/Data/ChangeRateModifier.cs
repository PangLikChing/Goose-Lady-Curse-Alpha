using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Change Rate Modifier", menuName = "Item/Change Rate Modifier")]
public class ChangeRateModifier : Modifier
{
    public SurvivalStat targetStat;

    private int index;
    public override void Apply()
    {
        index = targetStat.AddChangeRateModifier(this);
    }

    public override void Remove()
    {
        targetStat.RemoveChangeRateModifier(index);
    }
}
