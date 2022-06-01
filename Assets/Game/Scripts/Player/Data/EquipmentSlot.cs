using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : ScriptableObject
{
    public Equipment equipment;
    public bool isOccupied;

    public void Equip(Equipment equipment)
    {
        isOccupied = true;
        this.equipment = equipment;
        //Apply item bonus
    }

    public void UnEquip()
    {
        isOccupied = false;
        //Inventory.Add(equipment);
        equipment = null;
        //Remove item bonus
    }
}
