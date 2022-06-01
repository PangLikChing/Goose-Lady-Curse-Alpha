using Project.Build.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Equipment Slot", menuName = "Character/Equipment Slot")]
public class EquipmentSlot : ScriptableObject
{
    [ReadOnly]public Equipment equipment;
    [ReadOnly] public bool isOccupied;

    public void Equip(Equipment equipment)
    {
        isOccupied = true;
        this.equipment = equipment;
        //Apply item bonus
        //this.equipment;
    }

    public void UnEquip()
    {
        isOccupied = false;
        //Inventory.Add(equipment);
        equipment = null;
        //Remove item bonus
    }
}
