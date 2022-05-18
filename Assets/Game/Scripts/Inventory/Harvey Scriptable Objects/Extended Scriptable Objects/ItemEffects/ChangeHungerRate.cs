using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item Effects/Change Hunger Rate")]
public class ChangeHungerRate : ItemEffect
{
    [SerializeField] float changeHungerRate = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
