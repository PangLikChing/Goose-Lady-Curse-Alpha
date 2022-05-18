using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item Effects/Change Hunger")]
public class ChangeHunger : ItemEffect
{
    [SerializeField] float changeHunger = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
