using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventoryButton : MonoBehaviour
{
    [SerializeField] Transform inventoryBackground;
    public void Delete()
    {
        // Delete all children
        for (int i = 0; i < inventoryBackground.childCount; i++)
        {
            Destroy(inventoryBackground.GetChild(i).gameObject);
        }
    }
}
