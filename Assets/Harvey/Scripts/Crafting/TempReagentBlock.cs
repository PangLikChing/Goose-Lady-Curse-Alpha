using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TempReagentBlock : MonoBehaviour
{
    [SerializeField] Inventory myInventory;

    [SerializeField] CraftingManager craftingManager;

    TMP_Text acquiredNumberText;

    void Update()
    {
        if (craftingManager.craftingRecipe != null)
        {
            for (int i = 0; i < craftingManager.craftingRecipe.reagents.Length; i++)
            {
                transform.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text = SearchItem(craftingManager.craftingRecipe.reagents[i].item).ToString();
            }
        }
    }

    int SearchItem(Item item)
    {
        int temp = 0;

        for (int i = 0; i < myInventory.itemList.Count; i++)
        {
            for (int j = 0; j < myInventory.itemList[i].Length; j++)
            {
                if (myInventory.itemList[i][j].slottedItem == item)
                {
                    temp += myInventory.itemList[i][j].stackNumber;
                }
            }
        }

        return temp;
    }
}
