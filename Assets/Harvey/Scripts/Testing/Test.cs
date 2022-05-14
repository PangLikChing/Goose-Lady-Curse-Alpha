using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Just for testing
/// </summary>

public class Test : MonoBehaviour
{
    [SerializeField] Consumable testConsumable;

    [SerializeField] float testTimer = 0.0f;

    void Update()
    {
        if (testTimer >= 2.0f)
        {
            testConsumable.Consume();
            testTimer = 0.0f;
        }
        else
        {
            testTimer += Time.deltaTime;
        }
    }
}
