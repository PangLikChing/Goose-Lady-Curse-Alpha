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

    [SerializeField] int testStackNumber, initialStackNumber;

    [SerializeField] Inventory testInverntory;

    [SerializeField] float testTimer = 0.0f;

    private void Start()
    {
        // Initialize
        testInverntory = GetComponent<Inventory>();

        testInverntory.AddItem(testItem, initialStackNumber);
    }

    void Update()
    {
        if (testTimer >= 2.0f)
        {
            testInverntory.ConsumeItem(testItem, testStackNumber);

            testTimer = 0.0f;
        }
        else
        {
            testTimer += Time.deltaTime;
        }
    }
}
