using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Just for testing
/// </summary>

public class Test : MonoBehaviour
{
    [SerializeField] Consumable testConsumable;

    [SerializeField] Container testContainer;

    [SerializeField] Inventory testInventory;

    [SerializeField] Item testItem;

    [SerializeField] PlayerInverntory playerInverntory;

    [SerializeField] int testStackNumber;

    [SerializeField] float testTimer = 0.0f;

    void Update()
    {
        if (testTimer >= 2.0f)
        {
            //testContainer.DisplayItems();

            //testInventory.DisplayContainers();

            playerInverntory.AddItem(testItem, testStackNumber);

            //playerInverntory.ConsumeItem(testItem, testStackNumber);

            testTimer = 0.0f;
        }
        else
        {
            testTimer += Time.deltaTime;
        }
    }
}
