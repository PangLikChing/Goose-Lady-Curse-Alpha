using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item Effects/Change Health Rate")]
public class ChangeHealthRate : ItemEffect
{
    [SerializeField] float changeHealthRate = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
