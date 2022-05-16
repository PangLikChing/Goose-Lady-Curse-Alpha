using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item Effects/Change Thrist Rate")]
public class ChangeThristRate : ItemEffect
{
    [SerializeField] float changeThristRate = 0;

    public override void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
