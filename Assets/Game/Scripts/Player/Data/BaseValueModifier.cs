using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Base Value Modifier", menuName = "Item/Base Value Modifier")]
public class BaseValueModifier : Modifier
{
    public Stat targetStat;
    public override void Apply()
    {
        targetStat.AddBaseValueModifier(this);
    }

    public override void Remove()
    {
        targetStat.RemoveBaseValueModifier(this);
    }
}
