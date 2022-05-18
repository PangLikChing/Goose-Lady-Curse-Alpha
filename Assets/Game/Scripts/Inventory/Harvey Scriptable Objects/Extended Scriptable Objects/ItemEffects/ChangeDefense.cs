using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item Effects/Change Defense")]
public class ChangeDefense : ItemEffect
{
    [SerializeField] float changeDefense = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
