using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item Effects/Change Body Temperature")]
public class ChangeBodyTemperature : ItemEffect
{
    [SerializeField] float changeBodyTemperature = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
