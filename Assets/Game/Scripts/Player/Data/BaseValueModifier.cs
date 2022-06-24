using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Base Value Modifier", menuName = "Character/Base Value Modifier")]
public class BaseValueModifier : Modifier
{
    public Stat targetStat;
    private int index;
    public override void Apply()
    {
        index = targetStat.AddBaseValueModifier(this);
    }

    public override void Remove()
    {
        targetStat.RemoveBaseValueModifier(index);
    }
}
