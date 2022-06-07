using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChecker : MonoBehaviour
{
    //private GameObject inventory;
    //private List<ItemSlot[]> itemList = new List<ItemSlot[]>();
    private GameObject door;
    private bool KeyObtained;
    private KeyListener keylistener;

    void OnDestroy()
    {
        Debug.Log("OnDestroy was hit");
        //inventory = GameObject.Find("Player Inventory");
        door = GameObject.Find("Door");
        keylistener = GameObject.Find("KeyListenerObject").GetComponent<KeyListener>();
        KeyObtained = keylistener.GetKeyListener();

        if (KeyObtained == true)
        {
            door.SetActive(false);
            KeyObtained = false;
        }

    //    itemList = inventory.GetComponent<Inventory>().GetInventory();
    //    // Search for an existing same item
    //    // For every bag in player's inventory
    //    for (int i = 0; i < itemList.Count; i++)
    //    {
    //        Debug.Log("First for hit");
    //        // For every ItemSlot in that bag
    //        for (int j = 0; j < itemList[i].Length; j++)
    //        {
    //            Debug.Log("second for hit");
    //            // If there is an item in that ItemSlot
    //            if (itemList[i][j].slottedItem != null)
    //            {
    //                Debug.Log("If there is an item hit");
    //                // If that slottedItem in that ItemSlot is the same as item getting added
    //                // and will not exceed the stack's max stack number if we add those 2 together
    //                //if (itemList[i][j].slottedItem == key)
    //                if (itemList[i][j].GetItem().GetitemDisplayName() == "Strange Key")
    //                {
    //                    // Throw a debug message
    //                    //Debug.Log($"Key {key.name}(s) found in bag {i} slot {j}");
    //                    door.SetActive(false);
    //                }
    //            }
    //        }
    //    }
    }
}
