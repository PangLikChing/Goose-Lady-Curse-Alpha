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
    [SerializeField] Item testItem;

    [SerializeField] Inventory playerInverntory;

    [SerializeField] int testStackNumber;

    [SerializeField] float testTimer = 0.0f;

    void Update()
    {
        if (testTimer >= 2.0f)
        {
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
