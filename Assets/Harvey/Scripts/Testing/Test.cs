using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Just for testing
/// </summary>

public class Test : MonoBehaviour
{
    [SerializeField] Consumable testConsumable;

    [SerializeField] Container testContainer;

    [SerializeField] Inventory testInventory;

    [SerializeField] float testTimer = 0.0f;

    void Update()
    {
        if (testTimer >= 2.0f)
        {
            //testConsumable.Consume();
            //testContainer.DisplayItems();
            testInventory.DisplayContainers();
            testTimer = 0.0f;
        }
        else
        {
            testTimer += Time.deltaTime;
        }
    }
}
