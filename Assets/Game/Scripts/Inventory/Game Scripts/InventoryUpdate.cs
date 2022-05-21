using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is responsible for updating the UI of the player inventory
/// </summary>

public class InventoryUpdate : MonoBehaviour
{
    private List<Container> bags;

    // myInventory is the inventory scriptable object of the player
    [SerializeField] Inventory myInventory;

    void Start()
    {
        // Cache the bags
        bags = myInventory.bagSlots;
    }

    void LateUpdate()
    {
        // Read Data
        // For every bag
        for (int i = 0; i < bags.Count; i++)
        {
            // For eveny item in the bag
            for (int j = 0; j < bags[i].heldItems.Length; j++)
            {
                // If the slot has an item slotted
                if (transform.GetChild(j).childCount != 0)
                {
                    // Cache the current inventory slot
                    Transform currentSlot = transform.GetChild(j).GetChild(0);

                    // Assign container to the inventory slots
                    currentSlot.parent.GetComponent<InventorySlot>().slottedItem = bags[i].heldItems[j].slottedItem;
                    currentSlot.parent.GetComponent<InventorySlot>().stackNumber = bags[i].heldItems[j].stackNumber;
                    bags[i].heldItems[j].slottedItem = currentSlot.parent.GetComponent<InventorySlot>().slottedItem;
                    bags[i].heldItems[j].stackNumber = currentSlot.parent.GetComponent<InventorySlot>().stackNumber;

                    // If there is an item in that slot
                    if (bags[i].heldItems[j] != null)
                    {
                        // If the stack number of the item in that inventory slot is larger than or equals to 2
                        if (bags[i].heldItems[j].stackNumber >= 2)
                        {
                            // Change the stack number text to the stackNumber of the item in the inventory slot
                            //currentSlot.GetChild(0).GetComponent<TMP_Text>().text = bags[i].heldItems[j].stackNumber.ToString();
                            currentSlot.GetChild(0).GetComponent<TMP_Text>().text = currentSlot.parent.GetComponent<InventorySlot>().stackNumber.ToString();

                            // Enable the stack number text
                            currentSlot.GetChild(0).gameObject.SetActive(true);
                        }
                        // If the stack number of the item in that inventory slot is less than 2
                        else
                        {
                            // Disable the stack number text
                            currentSlot.GetChild(0).gameObject.SetActive(false);
                        }
                    }
                    // Else
                    else
                    {
                        // Remove the sprite
                        currentSlot.GetComponent<Image>().sprite = null;

                        // Disable the stack number text
                        currentSlot.GetChild(0).gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
